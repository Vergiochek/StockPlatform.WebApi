using MongoDB.Bson.Serialization.Attributes;
using System;

namespace StockPlatfrom.Core
{
    public class Author
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string AuthorNickName { get; set; }
        public int Age { get; set; }
        public DateTime DateOfAccountCreation { get; set; }
    }
}
