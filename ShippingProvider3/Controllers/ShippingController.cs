using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShippingProvider3.Dtos;

namespace ShippingProvider3.Controllers
{
    [Produces("application/xml")]
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<float>> GetCheapest([FromBody] ShippingRequestDto dto)
        {
            await Task.Delay(1000);
            return Ok(155.25);
        }
    }
}
