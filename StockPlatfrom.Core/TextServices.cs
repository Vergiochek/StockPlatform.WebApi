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

        public List<Text> GetTexts() => _texts.Find(text => true).ToList();
    }
}
