using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

public class MemberService
{
    private readonly IMongoCollection<Member> _memberCollection;

    public MemberService()
    {
        var db = MongoDBClient.GetDatabase();
        _memberCollection = db.GetCollection<Member>("Member");
    }
    
    public Member GetById(ObjectId id)
    {
        return _memberCollection.Find(m => m.Id == id).FirstOrDefault();
    }

    public Member GetByEmailAndPassword(string email, string password)
    {
        return _memberCollection.Find(m => m.email == email && m.password == password).FirstOrDefault();
    }


}
