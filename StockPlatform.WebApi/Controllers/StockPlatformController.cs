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
    public class StockPlatformController : ControllerBase
    {
        private readonly ITextServices _textServices;
        private readonly IPhotoServices _photoServices;
        public StockPlatformController(IPhotoServices photoServices, ITextServices textServices)
        {
            _photoServices = photoServices;
            _textServices = textServices;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(new { Photos = _photoServices.GetPhotos(), Texts = _textServices.GetTexts() });
        }
    }
}
