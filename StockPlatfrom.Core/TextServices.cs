using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace StockPlatfrom.Core
{
    public class TextServices : ITextServices
    {
        private readonly IMongoCollection<Text> _texts;

        public TextServices(IDbClient dbClient)
        {
            _texts = dbClient.GetTextsCollection();
        }

        public Text AddText(Text text)
        {
            _texts.InsertOne(text);
            return text;
        }

        public Text GetText(string id) => _texts.Find(text => text.Id == id).First();

        public List<Text> GetTexts() => _texts.Find(text => true).ToList();
    }
}
