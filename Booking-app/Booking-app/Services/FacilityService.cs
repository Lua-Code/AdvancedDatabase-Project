using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

public class FacilityService
{
    private readonly IMongoCollection<Facility> _facilityCollection;

    public FacilityService()
    {
        var db = MongoDBClient.GetDatabase();
        _facilityCollection = db.GetCollection<Facility>("Facility");
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

