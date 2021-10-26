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

        public void DeleteText(string id)
        {
            _texts.DeleteOne(text => text.Id == id);
        }

        public Text GetText(string id) => _texts.Find(text => text.Id == id).First();

        public List<Text> GetTexts() => _texts.Find(text => true).ToList();

        public Text UpdateText(Text text)
        {
            GetText(text.Id);
            _texts.ReplaceOne(b => b.Id == text.Id, text);
            return text;
        }
    }
}
