using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

public class Member
{
    [BsonId]
    public ObjectId Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string MembershipLevel { get; set; }
    public DateTime JoinDate { get; set; }
    public string MembershipStatus { get; set; }
}
