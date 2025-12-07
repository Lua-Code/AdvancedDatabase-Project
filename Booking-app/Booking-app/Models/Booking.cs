using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

public class Booking
{
    [BsonId]
    public ObjectId Id { get; set; }
    public ObjectId membed_id { get; set; }
    public ObjectId facility_id { get; set; }
    public ObjectId staff_id { get; set; }
    public DateTime bookingDate { get; set; }
    public int startTime { get; set; }
    public int endTime { get; set; }
    public string Status { get; set; }
    public DateTime creationDate { get; set; }
}
