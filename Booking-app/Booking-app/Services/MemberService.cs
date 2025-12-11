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

    public Member GetByEmail(string email)
    {
        return _memberCollection.Find(m => m.email == email).FirstOrDefault();
    }

    public bool AddMember(Member member)
    {
        try
        {
            _memberCollection.InsertOne(member);

            return true; // success
        }
        catch
        {
            return false; // failed
        }
    }

    public bool DeleteMember(Member member)
    {
        var result = _memberCollection.DeleteOne(m => m.Id == member.Id);
        return result.DeletedCount > 0;
    }

    public bool UpdateMember(Member member)
    {
        if (member == null || member.Id == ObjectId.Empty)
            return false;

        var filter = Builders<Member>.Filter.Eq(m => m.Id, member.Id);

        var update = Builders<Member>.Update
            .Set(m => m.name, member.name)
            .Set(m => m.email, member.email)
            .Set(m => m.phone, member.phone)
            .Set(m => m.password, member.password)
            .Set(m => m.membershipLevel, member.membershipLevel)
            .Set(m => m.membershipStatus, member.membershipStatus)
            .Set(m => m.joinDate, member.joinDate);

        var result = _memberCollection.UpdateOne(filter, update);
        return result.ModifiedCount > 0;
    }





}
