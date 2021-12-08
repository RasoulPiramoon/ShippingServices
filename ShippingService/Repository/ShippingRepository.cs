using ShippingService.Dtos;
using ShippingService.Helper;
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

        private string Convert(ServicesInfo info, string data)
        {
            data = data.Replace(nameof(info.MappingService.ShippingSourceAddress), info.MappingService.ShippingSourceAddress);
            data = data.Replace(nameof(info.MappingService.ShippingDestinationAddress), info.MappingService.ShippingDestinationAddress);
            data = data.Replace(nameof(info.MappingService.ParcelDimensions), info.MappingService.ParcelDimensions);
            data = data.Replace(nameof(info.MappingService.Height), info.MappingService.Height);
            data = data.Replace(nameof(info.MappingService.Length), info.MappingService.Length);
            data = data.Replace(nameof(info.MappingService.Weight), info.MappingService.Weight);

            return data;
        }
        public async Task<float> GetCheapest(ShippingRequestDto dto)
        {
            try
            {
                List<Task<float>> tasks = new List<Task<float>>();
                //tasks.Add(calApi.Call2("http://localhost:3208/api/Shipping", dto.GetJson()));
                //tasks.Add(calApi.Call3("http://localhost:3206/api/Shipping", dto.GetXml()));
                foreach (var item in AllServices.GetAll())
                {
                    if(item.ContentType == Helper.ContentTypeEnum.ApplicationJson)
                        tasks.Add(calApi.Call2(item.Url, Convert(item, dto.GetJson())));
                    else
                        tasks.Add(calApi.Call3(item.Url, Convert(item, dto.GetXml())));
                }
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
