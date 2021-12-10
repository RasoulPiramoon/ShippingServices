using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.Helper
{
    public class ServiceInfo
    {
        public string ServiceName { get; set; }
        public string Url { get; set; }
        public bool IsActive { get; set; }
        public ContentTypeEnum ContentType { get; set; }
        public MappingService MappingService { get; set; }
    }
}
