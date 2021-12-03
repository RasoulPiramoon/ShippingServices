using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.Dtos
{
    public class ParcelDimensions
    {
        public double Weight { get; set; }
        public double Length { get; set; }
        public double Height { get; set; }
    }
}
