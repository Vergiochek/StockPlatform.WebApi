using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPlatfrom.Core
{
    public interface ITextServices
    {
        List<Text> GetTexts();
        Text GetText(string id);
        Text AddText(Text text);

        void DeleteText(string id);
        Text UpdateText(Text text);
    }
}
