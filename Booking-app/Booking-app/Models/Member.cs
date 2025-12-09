using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

public class Member : IUser
{
    [BsonId]
    public ObjectId Id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string phone { get; set; }
    public string membershipLevel { get; set; }
    public DateTime joinDate { get; set; }
    public string membershipStatus { get; set; }
}
