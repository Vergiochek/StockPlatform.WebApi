using MongoDB.Bson.Serialization.Attributes;
using System;

namespace StockPlatfrom.Core
{
    public class Photo
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContentLink { get; set; }
        public string Sizes { get; set; }
        public DateTime DateOfCreation { get; set; }
        public double Price { get; set; }
        public Author Author { get; set; }
        public int NumberOfPurchases { get; set; }
    }
}
