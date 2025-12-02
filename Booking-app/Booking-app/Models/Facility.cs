using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

public class Facility
{
    [BsonId]
    public ObjectId Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Location { get; set; }
    public string Availability { get; set; }
    public int Capacity { get; set; }
    public decimal HourlyRate { get; set; }
}
