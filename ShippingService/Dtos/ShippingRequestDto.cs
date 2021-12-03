using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.Dtos
{
    public class ShippingRequestDto
    {
        public Address ShippingSourceAddress { get; set; }
        public Address ShippingDestinationAddress { get; set; }
        public List<ParcelDimensions> ParcelDimensions { get; set; }

    }
}
