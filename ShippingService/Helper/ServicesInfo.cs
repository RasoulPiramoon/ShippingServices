using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.Helper
{
    public class ServicesInfo
    {
        public string ServiceName { get; set; }
        public string Url { get; set; }
        public bool IsActive { get; set; }
        public ContentTypeEnum ContentType { get; set; }
        public MappingService MappingService { get; set; }
    }

    public enum ContentTypeEnum
    {
        ApplicationJson,
        ApplicationXml
    }
    public class MappingService
    {
        public string ShippingSourceAddress { get; set; }
        public string ShippingDestinationAddress { get; set; }
        public string ParcelDimensions { get; set; }
        public string Weight { get; set; }
        public string Length { get; set; }
        public string Height { get; set; }
    }
}
