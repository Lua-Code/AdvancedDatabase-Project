using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

public class Booking
{
    [BsonId]
    public ObjectId Id { get; set; }
    public ObjectId MemberId { get; set; }
    public ObjectId FacilityId { get; set; }
    public ObjectId StaffId { get; set; }
    public DateTime BookingDate { get; set; }
    public int StartTime { get; set; }
    public int EndTime { get; set; }
    public string Status { get; set; }
    public DateTime CreationDate { get; set; }
}
