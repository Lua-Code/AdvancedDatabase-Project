using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

public class Staff
{
    [BsonId]
    public ObjectId Id { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}
