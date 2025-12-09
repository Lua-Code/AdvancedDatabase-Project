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

    public BookingService()
    {
        var db = MongoDBClient.GetDatabase();
        _bookingCollection = db.GetCollection<Booking>("Booking");

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


    public List<Booking> getBookingsByFacilityIdAndDate(ObjectId facilityId,DateTime date)
    {
        var db = MongoDBClient.GetDatabase();

        DateTime dayStart = date.Date;                 
        DateTime dayEnd = dayStart.AddDays(1).AddTicks(-1); 

        var filter = Builders<Booking>.Filter.And(
            Builders<Booking>.Filter.Eq(b => b.facility_id, facilityId),
            Builders<Booking>.Filter.Gte(b => b.bookingDate, dayStart),
            Builders<Booking>.Filter.Lte(b => b.bookingDate, dayEnd)
        );

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