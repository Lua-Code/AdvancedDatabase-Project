using MongoDB.Driver;

public static class MongoDBClient
{
    private static readonly IMongoClient _client;
    private static readonly IMongoDatabase _db;

    static MongoDBClient()
    {
        _client = new MongoClient("mongodb://localhost:27017/");
        _db = _client.GetDatabase("ClubDB");
    }

    public static IMongoDatabase GetDatabase()
    {
        return _db;
    }
}
