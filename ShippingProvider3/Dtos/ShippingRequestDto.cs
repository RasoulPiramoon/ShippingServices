using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingProvider3.Dtos
{
    public class ShippingRequestDto
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public List<ParcelDimension> Dimensions { get; set; }

    }
}
