using ShippingService.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.Dtos
{
    public static class AllServices
    {
        public static List<ServicesInfo> GetAll()
        {
            return new List<ServicesInfo>
            {
                new ServicesInfo
                {
                    ServiceName = "Digi",
                    ContentType = ContentTypeEnum.ApplicationJson,
                    Url = "http://localhost:3208/api/Shipping",
                    IsActive = true,
                    MappingService = new MappingService { 
                        ShippingDestinationAddress = "DestinationAddress",
                        ShippingSourceAddress = "SourceAddress",
                        ParcelDimensions = "Dimensions",
                        Height = "Height",
                        Length = "Length",
                        Weight = "Weight"
                    }
                },
                new ServicesInfo
                {
                    ServiceName = "Shop1",
                    ContentType = ContentTypeEnum.ApplicationXml,
                    Url = "http://localhost:3206/api/Shipping",
                    IsActive = true,
                    MappingService = new MappingService {
                        ShippingDestinationAddress = "Destination",
                        ShippingSourceAddress = "Source",
                        ParcelDimensions = "Dimensions",
                        Height = "H",
                        Length = "L",
                        Weight = "W"
                    }
                }
            };
        }
    }
}
