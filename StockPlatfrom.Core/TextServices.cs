using System;
using System.Collections.Generic;

namespace StockPlatfrom.Core
{
    public class TextServices : ITextServices
    {
        public List<Text> GetTexts()
        {
            return new List<Text>
            {
                new Text
                {
                    Name = "Test",
                    Price = 9.99
                }
            };
        }
    }
}
