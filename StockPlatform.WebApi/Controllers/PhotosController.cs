using Microsoft.AspNetCore.Mvc;
using StockPlatfrom.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockPlatform.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IPhotoServices _photoServices;
        public PhotosController(IPhotoServices photoServices)
        {
            _photoServices = photoServices;
        }

        [HttpGet]
        public IActionResult GetPhotos()
        {
            return Ok(_photoServices.GetPhotos());
        }

        [HttpGet("{id}", Name = "GetPhoto")]
        public IActionResult GetPhoto(string id)
        {
            return Ok(_photoServices.GetPhoto(id));
        }

        [HttpPost]
        public IActionResult AddPhoto(Photo photo)
        {
            _photoServices.AddPhoto(photo);
            return CreatedAtRoute("GetPhoto", new { id = photo.Id }, photo);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePhoto(string id)
        {
            _photoServices.DeletePhoto(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdatePhoto(Photo photo)
        {
            return Ok(_photoServices.UpdatePhoto(photo));
        }
    }
}
