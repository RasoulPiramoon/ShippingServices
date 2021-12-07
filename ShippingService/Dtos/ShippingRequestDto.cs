using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.Dtos
{
    public class ShippingRequestDto
    {
        public string ShippingSourceAddress { get; set; }
        public string ShippingDestinationAddress { get; set; }
        public List<ParcelDimensions> ParcelDimensions { get; set; }

    }
}
