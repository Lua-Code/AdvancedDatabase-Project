using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

public class UsageLogService
{
    private readonly IMongoCollection<UsageLog> _usageLogCollection;

    public UsageLogService()
    {
        var db = MongoDBClient.GetDatabase();
        _usageLogCollection = db.GetCollection<UsageLog>("UsageLog");
    }

    public void Create(UsageLog log)
    {
        _usageLogCollection.InsertOne(log);
    }

    public bool ExistsForBooking(ObjectId bookingId)
    {
        return _usageLogCollection.Find(l => l.booking_id == bookingId).Any();
    }

    public List<UsageLog> GetLogsByStaff(ObjectId staffId)
    {
        var bookingService = new BookingService();
        var bookings = bookingService.GetBookingsByStaffId(staffId);
        var bookingIds = bookings.Select(b => b.Id).ToList();

        return _usageLogCollection
            .Find(l => bookingIds.Contains(l.booking_id))
            .ToList();
    }

    public List<UsageLog> GetAll()
    {
        return _usageLogCollection.Find(_ => true).ToList();
    }
}
