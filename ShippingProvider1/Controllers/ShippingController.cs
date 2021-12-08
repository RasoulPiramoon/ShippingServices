using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShippingProvider1.Dtos;

namespace ShippingProvider1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<float>> GetCheapest([FromBody] ShippingRequestDto dto)
        {
            await Task.Delay(1000);
            return Ok(150.5);
        }
    }
}
