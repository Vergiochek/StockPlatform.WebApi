using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPlatfrom.Core
{
    public interface IDbClient
    {
        IMongoCollection<Text> GetTextsCollection();
        IMongoCollection<Photo> GetPhotosCollection();
    }
}
