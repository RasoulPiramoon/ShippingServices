using ShippingService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.Repository
{
    public class ShippingRepository : IShippingRepository
    {
        private readonly ICallApi calApi;

        public ShippingRepository(ICallApi calApi)
        {
            this.calApi = calApi;
        }

        public async Task<float> GetCheapest(ShippingRequestDto dto)
        {
            try
            {
                List<Task<float>> tasks = new List<Task<float>>();
                tasks.Add(calApi.Call2("http://localhost:3208/api/Shipping", dto));
                tasks.Add(calApi.Call3("http://localhost:3206/api/Shipping", dto));
                //foreach (var item in collection)
                //{

                //}
                var result = await Task.WhenAll(tasks);
                var cheapest = result.Where(c => c >= 0).Min();
                return cheapest;
            }
            catch(Exception ex)
            {
                //Log Error
                throw ex;
            }
        }
    }
}
