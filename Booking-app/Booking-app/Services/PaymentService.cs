using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

public class PaymentService {

    private readonly IMongoCollection<Payment> _paymentCollection;

    public PaymentService()
    {
        var db = MongoDBClient.GetDatabase();
        _paymentCollection = db.GetCollection<Payment>("Payment");
    }

    public void CreatePayment(ObjectId memberId, ObjectId bookingId, decimal amount, string paymentMethod,string paymentType )
    {
        var payment = new Payment
        {
            member_id = memberId,
            booking_id = bookingId,
            amount = amount,
            paymentMethod = paymentMethod,
            paymentType = paymentType,
            paymentDate = DateTime.UtcNow,
            status = "Completed"
        };

        _paymentCollection.InsertOne(payment);
    }





}