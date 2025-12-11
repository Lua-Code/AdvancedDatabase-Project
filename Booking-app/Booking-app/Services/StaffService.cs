using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

public class StaffService
{
    private readonly IMongoCollection<Staff> _staffCollection;
    private BookingService _bookingService;

    public BookingService BookingService
    {
        get => _bookingService ?? throw new InvalidOperationException("BookingService must be assigned before using this method.");
        set => _bookingService = value ?? throw new ArgumentNullException(nameof(value));
    }


    public StaffService()
    {
        var db = MongoDBClient.GetDatabase();
        _staffCollection = db.GetCollection<Staff>("Staff");
    }

    public Staff GetByEmail(string email)
    {
        return _staffCollection.Find(m => m.email == email).FirstOrDefault();
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
            var hasConflict = BookingService.HasConflict(staff.Id, facilityId, bookingDate, startTime, endTime);

            if (!hasConflict)
            {
                return staff; // staff is free
            }
        }

        return null; // no staff available
    }

    public bool ReassignStaff(ObjectId oldStaffId)
    {
        var bookingsToReassign = BookingService.GetBookingsByStaffId(oldStaffId);

        if (bookingsToReassign.Count == 0)
            return true;

        foreach (var booking in bookingsToReassign)
        {
            var newStaff = GetAvailableStaff(
                booking.facility_id,
                booking.bookingDate,
                booking.startTime,
                booking.endTime
            );

            if (newStaff == null)
            {
                booking.staff_id = ObjectId.Empty; // unassigned
            }
            else
            {
                booking.staff_id = newStaff.Id;
            }

            BookingService.UpdateBooking(booking); // use BookingService to save changes
        }

        return true;
    }

    public bool DeleteStaff(Staff staff)
    {
        ReassignStaff(staff.Id); // ensure bookings are reassigned/unassigned
        var result = _staffCollection.DeleteOne(s => s.Id == staff.Id);
        return result.DeletedCount > 0;
    }

    public bool UpdateStaff(Staff staff)
    {
        if (staff == null || staff.Id == ObjectId.Empty)
            return false;

        var filter = Builders<Staff>.Filter.Eq(s => s.Id, staff.Id);
        var update = Builders<Staff>.Update
            .Set(s => s.name, staff.name)
            .Set(s => s.email, staff.email)
            .Set(s => s.phone, staff.phone)
            .Set(s => s.password, staff.password)
            .Set(s => s.role, staff.role);

        var result = _staffCollection.UpdateOne(filter, update);
        return result.ModifiedCount > 0;
    }

    public bool AddStaff(Staff staff)
    {
        try
        {
            _staffCollection.InsertOne(staff);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding staff: {ex.Message}");
            return false;
        }

    }
}
