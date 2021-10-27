using MongoDB.Bson.Serialization.Attributes;

namespace StockPlatfrom.Core
{
    public class Author
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public int Age { get; set; }
        public string DateOfAccountCreation { get; set; }
    }
}
