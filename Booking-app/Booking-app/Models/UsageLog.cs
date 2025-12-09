using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

public class UsageLog
{
    [BsonId]
    public ObjectId Id { get; set; }
    public ObjectId booking_id { get; set; }
    public ObjectId member_id { get; set; }
    public ObjectId facility_id { get; set; }
    public int startTime { get; set; }
    public int endTime { get; set; }
    public int duration { get; set; }
}
