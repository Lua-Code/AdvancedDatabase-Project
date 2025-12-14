using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

public class FacilityService
{
    private readonly IMongoCollection<Facility> _facilityCollection;
    private MemberService _memberService;

    public FacilityService()
    {
        var db = MongoDBClient.GetDatabase();
        _facilityCollection = db.GetCollection<Facility>("Facility");
        _memberService = new MemberService();
    }

    public Facility GetById(ObjectId id)
    {
        return _facilityCollection.Find(f => f.Id == id).FirstOrDefault();
    }

    public decimal GetPriceByMembershipLevel(ObjectId user_id, ObjectId facility_id)
    {
        var facility = GetById(facility_id);
        decimal facilityHourlyRate = facility.hourlyRate;

        if (Session.IsStaff) return facilityHourlyRate; //staff has no discounts sad

        var member = _memberService.GetById(user_id);
        var membershipLevel = member.membershipLevel;
        var membershipStatus = member.membershipStatus;
        decimal discount = 0;

        if (membershipStatus == "Active") {
            if (membershipLevel == "Premium")
            {
                discount = 0.1m;
            }
            else if (membershipLevel == "VIP") {
                discount = 0.25m;
            }
        }
        return (1 - discount) * facilityHourlyRate;
    }

    public decimal GetPriceByTime(ObjectId facilityId,int startTime,int endTime)
    {
        var facility = GetById(facilityId);
        decimal facilityHourlyRate = facility.hourlyRate;

        int duration = endTime - startTime;
        decimal discount = 0;
        string membershipLevel = Session.getMembershipLevel();

        if (membershipLevel == "Premium")
        {
            discount = 0.1m;
        }
        else if (membershipLevel == "VIP")
        {
            discount = 0.25m;
        }

        return (1 - discount) * facilityHourlyRate * duration;






    }
    public List<Facility> GetAllFacilities()
    {
        return _facilityCollection.Find(f => true).ToList();
    }

    public List<Facility> GetByType(string type)
    {
        return _facilityCollection.Find(f => f.type == type).ToList();
    }

    public List<Facility> GetByName(string name)
    {
        return _facilityCollection.Find(f => f.name == name).ToList();
    }


    public Facility GetByNameLocationAndType(string name, string location, string type)
    {
        var filter = Builders<Facility>.Filter.And(
            Builders<Facility>.Filter.Regex(f => f.name, new BsonRegularExpression($"^{Regex.Escape(name)}$", "i")),
            Builders<Facility>.Filter.Regex(f => f.location, new BsonRegularExpression($"^{Regex.Escape(location)}$", "i")),
            Builders<Facility>.Filter.Regex(f => f.type, new BsonRegularExpression($"^{Regex.Escape(type)}$", "i"))
        );

        return _facilityCollection.Find(filter).FirstOrDefault();

    }


    public List<string> GetDistinctTypes()
    {
        return _facilityCollection.Distinct<string>("type", Builders<Facility>.Filter.Empty).ToList();
    }

    public bool AddFacility(Facility facility)
    {
        if (facility == null)
            return false;

        // Check for duplicates
        var existing = GetByNameLocationAndType(facility.name, facility.location, facility.type);
        if (existing != null)
            return false; 

        _facilityCollection.InsertOne(facility);
        return true;
    }

    public bool UpdateFacility(Facility facility)
    {
        if (facility == null || facility.Id == ObjectId.Empty)
            return false;

        var filter = Builders<Facility>.Filter.Eq(f => f.Id, facility.Id);
        var update = Builders<Facility>.Update
            .Set(f => f.name, facility.name)
            .Set(f => f.type, facility.type)
            .Set(f => f.location, facility.location)
            .Set(f => f.availability, facility.availability)
            .Set(f => f.capacity, facility.capacity)
            .Set(f => f.hourlyRate, facility.hourlyRate);

        var result = _facilityCollection.UpdateOne(filter, update);
        return result.ModifiedCount > 0;

    }

    public bool DeleteFacility(Facility facility)
    {
        
        var result = _facilityCollection.DeleteOne(f => f.Id == facility.Id);
        return result.DeletedCount > 0;
    }


}

