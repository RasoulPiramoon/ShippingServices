using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShippingService.Dtos;
using ShippingService.Repository;

namespace ShippingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController : ControllerBase
    {
        private readonly IShippingRepository shippingRepository;

        public ShippingController(IShippingRepository shippingRepository)
        {
            this.shippingRepository = shippingRepository;
        }

        [HttpPost]
        public async Task<ActionResult<float>> GetCheapest(ShippingRequestDto dto)
        {
            try
            {
                var cheapest = await shippingRepository.GetCheapest(dto);
                if (cheapest >= 0)
                    return Ok(cheapest);
                else
                    return BadRequest("Services have error");
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
