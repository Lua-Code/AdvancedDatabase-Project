using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

    public List<string> GetDistinctTypes()
    {
        return _facilityCollection.Distinct<string>("type", Builders<Facility>.Filter.Empty).ToList();
    }

}

