using ShippingService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.Repository
{
    public interface IShippingRepository
    {
        Task<decimal> GetCheapest(ShippingRequestDto dto);
    }
}
