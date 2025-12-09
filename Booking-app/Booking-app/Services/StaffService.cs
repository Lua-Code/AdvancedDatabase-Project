using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

public class StaffService
{
    private readonly IMongoCollection<Staff> _staffCollection;
    public StaffService()
    {
        var db = MongoDBClient.GetDatabase();
        _staffCollection = db.GetCollection<Staff>("Staff");
    }

    public Staff GetByEmailAndPassword(string email, string password)
    {
        return _staffCollection.Find(m => m.email == email && m.password == password).FirstOrDefault();
    }

    public Staff GetById(ObjectId id)
    {
        return _staffCollection.Find(m => m.Id == id).FirstOrDefault();
    }
}
