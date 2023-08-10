using LinkShortner.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LinkShortner.Services
{
    public class MongoDBService
    {
        private readonly IMongoCollection<Link> _linksCollection;

        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _linksCollection = database.GetCollection<Link>("Links");
        }

        public async Task<List<Link>> GetLinksAsync()
        {
            return (await _linksCollection.FindAsync(new BsonDocument())).ToList();
        }

        public async Task CreateAsync(Link link)
        {
            await _linksCollection.InsertOneAsync(link);
        }

        public async Task<Link> GetLinkByIdentifier(string identifier)
        {
            return (await _linksCollection.FindAsync(link => link.LinkIdentifier == identifier)).Single();
        }
    }
}
