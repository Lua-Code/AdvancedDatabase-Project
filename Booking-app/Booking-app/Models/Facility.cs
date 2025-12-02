using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

public class Facility
{
    [BsonId]
    public ObjectId Id { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public string location { get; set; }
    public string availability { get; set; }
    public int capacity { get; set; }
    public decimal hourlyRate { get; set; }
}
