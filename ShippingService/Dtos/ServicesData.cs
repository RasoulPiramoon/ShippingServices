using ShippingService.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.Dtos
{
    public static class ServicesData
    {
        public static List<ServiceInfo> GetAll()
        {
            return new List<ServiceInfo>
            {
                new ServiceInfo
                {
                    ServiceName = "Company1",
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
                new ServiceInfo
                {
                    ServiceName = "Company2",
                    ContentType = ContentTypeEnum.ApplicationJson,
                    Url = "http://localhost:3008/api/Shipping",
                    IsActive = true,
                    MappingService = new MappingService {
                        ShippingDestinationAddress = "Destination",
                        ShippingSourceAddress = "Source",
                        ParcelDimensions = "Dimensions",
                        Height = "H",
                        Length = "L",
                        Weight = "W"
                    }
                },
                new ServiceInfo
                {
                    ServiceName = "Company3",
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
