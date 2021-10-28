using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace StockPlatfrom.Core
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<Text> _texts;
        private readonly IMongoCollection<Photo> _photos;

        public DbClient(IOptions<StockPlatformDbConfig> stockplatformDbConfig)
        {
            var client = new MongoClient(stockplatformDbConfig.Value.Connection_String);
            var database = client.GetDatabase(stockplatformDbConfig.Value.Database_Name);
            _texts = database.GetCollection<Text>(stockplatformDbConfig.Value.Texts_Collection_Name);
            _photos = database.GetCollection<Photo>(stockplatformDbConfig.Value.Photos_Collection_Name);
        }

        public IMongoCollection<Photo> GetPhotosCollection() => _photos;

        public IMongoCollection<Text> GetTextsCollection() => _texts;
    }
}
