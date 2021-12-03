using ShippingService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.Repository
{
    public class ShippingRepository : IShippingRepository
    {
        public async Task<decimal> GetCheapest(ShippingRequestDto dto)
        {
            try
            {
                //foreach (var item in collection)
                //{

                //}
                return 1;
            }
            catch(Exception ex)
            {
                //Log Error
                throw ex;
            }
        }
    }
}
