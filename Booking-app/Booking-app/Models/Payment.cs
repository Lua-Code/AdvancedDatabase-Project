using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

public class Payment
{
    [BsonId]
    public ObjectId Id { get; set; }
    public ObjectId member_id { get; set; }
    public decimal amount { get; set; }
    public DateTime paymentDate { get; set; }
    public string paymentMethod { get; set; }
    public string paymentType { get; set; }
    public ObjectId booking_id { get; set; }
    public string status { get; set; }
}
