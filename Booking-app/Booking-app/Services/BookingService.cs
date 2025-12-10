using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

public class BookingService
{
    private readonly IMongoCollection<Booking> _bookingCollection;
    private readonly StaffService _staffService;

    public BookingService()
    {
        var db = MongoDBClient.GetDatabase();
        _bookingCollection = db.GetCollection<Booking>("Booking");
        _staffService = new StaffService();

    }

    public bool CreateBookings(ObjectId memberId,ObjectId facilityId, List<(int Start, int End)> selectedSlots,DateTime bookingDate)
    {
        try
        {
            if (selectedSlots == null || selectedSlots.Count == 0)
                return false;

            selectedSlots.Sort((a, b) => a.Start.CompareTo(b.Start));

            List<(int Start, int End)> mergedSlots = new List<(int Start, int End)>();
            int currentStart = selectedSlots[0].Start;
            int currentEnd = selectedSlots[0].End;

            for (int i = 1; i < selectedSlots.Count; i++)
            {
                var slot = selectedSlots[i];

                if (slot.Start == currentEnd)
                {
                    currentEnd = slot.End; 
                }
                else
                {
                    mergedSlots.Add((currentStart, currentEnd));
                    currentStart = slot.Start;
                    currentEnd = slot.End;
                }
            }


            mergedSlots.Add((currentStart, currentEnd));

            foreach (var bookingSlot in mergedSlots)
            {
                Staff availableStaff = _staffService.GetAvailableStaff(facilityId, bookingDate, bookingSlot.Start, bookingSlot.End);

                Booking booking = new Booking
                {
                    member_id = memberId,
                    facility_id = facilityId,
                    staff_id = availableStaff.Id,
                    bookingDate = bookingDate,
                    startTime = bookingSlot.Start,
                    endTime = bookingSlot.End,
                    Status = "Pending",
                    creationDate = DateTime.UtcNow
                };

                _bookingCollection.InsertOne(booking);
            }

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating booking: {ex.Message}");
            return false;
        }
    }



    public List<Booking> GetBookingsByMemberId(ObjectId memberId)
    {
        var filter = Builders<Booking>.Filter.Eq(b => b.member_id, memberId);
        var sort = Builders<Booking>.Sort.Ascending(b => b.bookingDate);
        return _bookingCollection.Find(filter).Sort(sort).ToList();
    }

    public bool UnbookBooking(string bookingId)
    {
        var filter = Builders<Booking>.Filter.Eq(b => b.Id, new ObjectId(bookingId));
        var update = Builders<Booking>.Update.Set(b => b.Status, "Cancelled");
        var result = _bookingCollection.UpdateOne(filter, update);

        return result.MatchedCount > 0;
    }


    public List<Booking> getBookingsByFacilityIdAndDate(ObjectId facilityId, DateTime date)
    {
        var dayStart = date.Date.ToUniversalTime();
        var dayEnd = dayStart.AddDays(1);

        var filterBuilder = Builders<Booking>.Filter;
        var filter = filterBuilder.Eq(b => b.facility_id, facilityId) &
                     filterBuilder.Gte(b => b.bookingDate, dayStart) &
                     filterBuilder.Lt(b => b.bookingDate, dayEnd);

        return _bookingCollection.Find(filter).ToList();
    }



    public List<(int Start, int End)> GetAvailableSlots(ObjectId facilityId, DateTime date, int openingHour = 8, int closingHour = 23)
    {
        var bookings = getBookingsByFacilityIdAndDate(facilityId, date);
        bookings.Sort((a, b) => a.startTime.CompareTo(b.startTime));

        var available = new List<(int, int)>();
        int currentHour = openingHour;

        foreach (var booking in bookings)
        {
            while (currentHour < booking.startTime)
            {
                available.Add((currentHour, currentHour + 1));
                currentHour++;
            }

            currentHour = Math.Max(currentHour, booking.endTime);
        }

        while (currentHour < closingHour)
        {
            available.Add((currentHour, currentHour + 1));
            currentHour++;
        }

        return available;
    }






}