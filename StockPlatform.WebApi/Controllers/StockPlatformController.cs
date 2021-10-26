﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{id}", Name = "GetText")]
        public IActionResult GetText(string id)
        {
            return Ok(_textServices.GetText(id));
        }

        [HttpPost]
        public IActionResult AddText(Text text)
        {
            _textServices.AddText(text);
            return CreatedAtRoute("GetText", new { id = text.Id }, text);
        }
    }
}
