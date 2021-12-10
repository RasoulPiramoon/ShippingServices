using ShippingService.Dtos;
using ShippingService.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        private string Convert(ServiceInfo info, string data)
        {
            StringBuilder sb = new StringBuilder(data);
            sb.Replace(nameof(info.MappingService.ShippingSourceAddress), info.MappingService.ShippingSourceAddress);
            sb.Replace(nameof(info.MappingService.ShippingDestinationAddress), info.MappingService.ShippingDestinationAddress);
            sb.Replace(nameof(info.MappingService.ParcelDimensions), info.MappingService.ParcelDimensions);
            sb.Replace(nameof(info.MappingService.Height), info.MappingService.Height);
            sb.Replace(nameof(info.MappingService.Length), info.MappingService.Length);
            sb.Replace(nameof(info.MappingService.Weight), info.MappingService.Weight);

            return sb.ToString();
        }
        public async Task<float> GetCheapest(ShippingRequestDto dto)
        {
            try
            {
                List<Task<float>> tasks = new List<Task<float>>();
                foreach (var item in ServicesData.GetAll().Where(c => c.IsActive).ToList())
                {
                    if (item.ContentType == Helper.ContentTypeEnum.ApplicationJson)
                        tasks.Add(calApi.CallAsJson(item.Url, Convert(item, dto.GetJson())));
                    else
                        tasks.Add(calApi.CallAsXml(item.Url, Convert(item, dto.GetXml())));
                }
                var result = await Task.WhenAll(tasks);
                float cheapest = -1;
                if (result.Any(c => c > -1))
                    cheapest = result.Where(c => c >= 0).Min();
                return cheapest;
            }
            catch (Exception ex)
            {
                //Log Error
                throw ex;
            }
        }
    }
}
