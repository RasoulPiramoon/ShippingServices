using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingProvider2.Dtos
{
    public class ShippingRequestDto
    {
        public string SourceAddress { get; set; }
        public string DestinationAddress { get; set; }
        public List<ParcelDimension> Dimensions { get; set; }

    }
}
