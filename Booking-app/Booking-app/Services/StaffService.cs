using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

public class StaffService
{
    private readonly IMongoCollection<Staff> _staffCollection;
    private readonly IMongoCollection<Booking> _bookingCollection;
    public StaffService()
    {
        var db = MongoDBClient.GetDatabase();
        _staffCollection = db.GetCollection<Staff>("Staff");
        _bookingCollection = db.GetCollection<Booking>("Booking");
    }


    public Staff GetByEmailAndPassword(string email, string password)
    {
        return _staffCollection.Find(m => m.email == email && m.password == password).FirstOrDefault();
    }

    public Staff GetById(ObjectId id)
    {
        return _staffCollection.Find(m => m.Id == id).FirstOrDefault();
    }

    public Staff GetAvailableStaff(ObjectId facilityId, DateTime bookingDate, int startTime, int endTime)
    {
        var allStaff = _staffCollection.Find(_ => true).ToList();

        foreach (var staff in allStaff)
        {
            // check if this staff has any conflicting booking
            var filter = Builders<Booking>.Filter.And(
                Builders<Booking>.Filter.Eq(b => b.staff_id, staff.Id),
                Builders<Booking>.Filter.Eq(b => b.facility_id, facilityId),
                Builders<Booking>.Filter.Eq(b => b.bookingDate, bookingDate),
                Builders<Booking>.Filter.Lt(b => b.startTime, endTime),
                Builders<Booking>.Filter.Gt(b => b.endTime, startTime)
            );

            var conflict = _bookingCollection.Find(filter).FirstOrDefault();
            if (conflict == null)
            {
                // staff is free
                return staff;
            }
        }

        // no staff available
        return null;
    }

}
