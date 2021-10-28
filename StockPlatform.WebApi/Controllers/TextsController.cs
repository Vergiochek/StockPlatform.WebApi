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
    [Route("api/[controller]")]
    public class TextsController : ControllerBase
    {
        private readonly ITextServices _textServices;
        public TextsController(ITextServices textServices)
        {
            _textServices = textServices;
        }

        [HttpGet]
        public IActionResult GetTexts()
        {
            return Ok(_textServices.GetTexts());
        }

        [HttpGet("{id}", Name = "GetText")]
        public IActionResult GetText(int id)
        {
            return Ok(_textServices.GetText(id));
        }

        [HttpPost]
        public IActionResult AddText(Text text)
        {
            _textServices.AddText(text);
            return CreatedAtRoute("GetText", new { id = text.Id }, text);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteText(int id)
        {
            _textServices.DeleteText(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateText(Text text)
        {
            return Ok(_textServices.UpdateText(text));
        }
    }
}
