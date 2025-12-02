using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

public class UsageLog
{
    [BsonId]
    public ObjectId Id { get; set; }
    public ObjectId BookingId { get; set; }
    public ObjectId MemberId { get; set; }
    public ObjectId FacilityId { get; set; }
    public int StartTime { get; set; }
    public int EndTime { get; set; }
    public int Duration { get; set; }
}
