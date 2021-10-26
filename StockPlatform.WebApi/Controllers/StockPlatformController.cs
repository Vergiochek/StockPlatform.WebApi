using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StockPlatfrom.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockPlatform.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockPlatformController : ControllerBase
    {
        private readonly ITextServices _textServices;
        public StockPlatformController(ITextServices textServices)
        {
            _textServices = textServices;
        }

        [HttpGet]
        public IActionResult GetTexts()
        {
            return Ok(_textServices.GetTexts());
        }

        [HttpPost]
        public IActionResult AddText(Text text)
        {
            _textServices.AddText(text);
            return Ok(text);
        }
    }
}
