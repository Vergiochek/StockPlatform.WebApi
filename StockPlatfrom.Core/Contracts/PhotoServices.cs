using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace StockPlatfrom.Core
{
    public class PhotoServices : IPhotoServices
    {
        private readonly IMongoCollection<Photo> _photos;

        public PhotoServices(IDbClient dbClient)
        {
            _photos = dbClient.GetPhotosCollection();
        }

        public Photo AddPhoto(Photo photo)
        {
            _photos.InsertOne(photo);
            return photo;
        }

        public void DeletePhoto(int id)
        {
            _photos.DeleteOne(book => book.Id == id);
        }

        public Photo GetPhoto(int id) => _photos.Find(photo => photo.Id == id).First();

        public List<Photo> GetPhotos() => _photos.Find(photo => true).ToList();

        public Photo UpdatePhoto(Photo photo)
        {
            GetPhoto(photo.Id);
            _photos.ReplaceOne(b => b.Id == photo.Id, photo);
            return photo;
        }
    }
}
