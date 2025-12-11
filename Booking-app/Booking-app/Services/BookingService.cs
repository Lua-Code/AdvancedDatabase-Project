using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

public class BookingService
{
    private readonly IMongoCollection<Booking> _bookingCollection;
    private StaffService _staffService;

    public StaffService StaffService
    {
        get => _staffService ?? throw new InvalidOperationException("StaffService must be assigned before using this method.");
        set => _staffService = value ?? throw new ArgumentNullException(nameof(value));
    }

    public BookingService()
    {
        var db = MongoDBClient.GetDatabase();
        _bookingCollection = db.GetCollection<Booking>("Booking");
    }

    public bool CreateBookings(ObjectId memberId, ObjectId facilityId, List<(int Start, int End)> selectedSlots, DateTime bookingDate)
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
                Staff availableStaff = StaffService.GetAvailableStaff(facilityId, bookingDate, bookingSlot.Start, bookingSlot.End);

                Booking booking = new Booking
                {
                    member_id = memberId,
                    facility_id = facilityId,
                    staff_id = availableStaff?.Id ?? ObjectId.Empty,
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

    public bool HasConflict(ObjectId staffId, ObjectId facilityId, DateTime date, int startTime, int endTime)
    {
        var bookings = GetBookingsByStaffId(staffId);
        foreach (var b in bookings)
        {
            if (b.facility_id == facilityId &&
                b.bookingDate.Date == date.Date &&
                b.startTime < endTime &&
                b.endTime > startTime)
            {
                return true;
            }
        }
        return false;
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


    public List<Booking> GetBookingsByStaffId(ObjectId staffId)
    {
        return _bookingCollection
            .Find(b => b.staff_id == staffId)
            .ToList();
    }

    public bool UpdateBooking(Booking booking)
    {
        if (booking == null || booking.Id == ObjectId.Empty)
            return false;

        var filter = Builders<Booking>.Filter.Eq(b => b.Id, booking.Id);

        var update = Builders<Booking>.Update
            .Set(b => b.facility_id, booking.facility_id)
            .Set(b => b.staff_id, booking.staff_id)
            .Set(b => b.member_id, booking.member_id)
            .Set(b => b.bookingDate, booking.bookingDate)
            .Set(b => b.startTime, booking.startTime)
            .Set(b => b.endTime, booking.endTime)
            .Set(b => b.Status, booking.Status); 

        var result = _bookingCollection.UpdateOne(filter, update);
        return result.ModifiedCount > 0;
    }

}