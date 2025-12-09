using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

public class Staff : IUser
{
    [BsonId]
    public ObjectId Id { get; set; }
    public string name { get; set; }
    public string role { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    public string password { get; set; }
}
