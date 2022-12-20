using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CrownBackend.Domain.Interfaces.Services;
using System;
using CrownBackend.Domain.DTOs;
using CrownBackend.Domain.Models;

namespace CrownBackend.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ArrayController : ControllerBase
    {
        private readonly IArrayBinaryService _service;

        public ArrayController(IArrayBinaryService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost]
        public IActionResult OrderArray([FromBody]ConvertArrayBinaryRequest arrayBinay)
        {
            var resp = _service.ConvertToBinaryOrdered(arrayBinay);
            return Ok(resp);
        }
    }
}
