using ShippingService.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ShippingService.Dtos
{
    public class ShippingRequestDto
    {
        public string ShippingSourceAddress { get; set; }
        public string ShippingDestinationAddress { get; set; }
        public List<ParcelDimension> ParcelDimensions { get; set; }


        public string GetJson()
        {
            return JsonSerializer.Serialize(this);
        }

        public string GetXml()
        {
            string xmlData = string.Empty;
            using (var writer = new StringWriterWithEncoding(Encoding.UTF8))
            {
                new XmlSerializer(this.GetType()).Serialize(writer, this);
                xmlData = writer.ToString();
            }
            return xmlData;
        }
    }
}
