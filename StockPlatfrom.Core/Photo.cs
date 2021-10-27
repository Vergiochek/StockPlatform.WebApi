using MongoDB.Bson.Serialization.Attributes;

namespace StockPlatfrom.Core
{
    public class Photo
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string ContentLink { get; set; }
        public string Sizes { get; set; }
        public string DateOfCreation { get; set; }
        public double Price { get; set; }
        public string AuthorName { get; set; }
        public string AuthorNickName { get; set; }
        public int NumberOfPurchases { get; set; }
    }
}
