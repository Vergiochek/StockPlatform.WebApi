using MongoDB.Bson.Serialization.Attributes;
using System;

namespace StockPlatfrom.Core
{
    public class Text
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Size { get; set; }
        public DateTime DateOfCreation { get; set; }
        public double Price { get; set; }
        public Author Author { get; set; }
        public int NumberOfPurchases { get; set; }
    }
}
