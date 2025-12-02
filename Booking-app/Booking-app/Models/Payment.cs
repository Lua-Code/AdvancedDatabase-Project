using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

public class Payment
{
    [BsonId]
    public ObjectId Id { get; set; }
    public ObjectId MemberId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public string PaymentMethod { get; set; }
    public string PaymentType { get; set; }
    public ObjectId? BookingId { get; set; }
    public string Status { get; set; }
}
