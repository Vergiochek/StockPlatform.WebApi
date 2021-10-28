using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPlatfrom.Core
{
    public interface IPhotoServices
    {
        List<Photo> GetPhotos();
        Photo GetPhoto(int id);
        Photo AddPhoto(Photo photo);

        void DeletePhoto(int id);
        Photo UpdatePhoto(Photo photo);
    }
}
