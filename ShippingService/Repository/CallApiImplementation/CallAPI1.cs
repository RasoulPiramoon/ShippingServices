using ShippingService.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ShippingService.Repository.CallApiImplementation
{
    public class CallAPI1 : ICallApi
    {
        public Task<float> Call()
        {
            throw new NotImplementedException();
        }

        public async Task<float> Call2(string path, object data)
        {
            float totalAmount = 0;
            HttpClient client = new HttpClient();
            var jsonData = JsonSerializer.Serialize(data);
            var jsonData2 = JsonSerializer.SerializeToUtf8Bytes(data);
            var stringData = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(path, stringData);
            if (!response.IsSuccessStatusCode)
                totalAmount = - 1;
            else
            {
                var result = await response.Content.ReadAsStringAsync();
                var isSuccess = float.TryParse(result, out totalAmount);
                totalAmount = isSuccess ? totalAmount : -1;
            }

            return totalAmount;
        }

        public async Task<float> Call3(string path, object data)
        {
            float totalAmount = 0;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            string xmlData = string.Empty;
            using (var writer = new StringWriterWithEncoding(Encoding.UTF8))
            {
                new XmlSerializer(data.GetType()).Serialize(writer, data);
                xmlData = writer.ToString();
            }
            var stringData = new StringContent(xmlData, Encoding.UTF8, "application/xml");
            var response = await client.PostAsync(path, stringData);
            if (!response.IsSuccessStatusCode)
                totalAmount = -1;
            else
            {
                XDocument xdoc = XDocument.Parse(response.Content.ReadAsStringAsync().Result);
                var elem = ((System.Xml.Linq.XElement)xdoc.FirstNode).Value;
                var isSuccess = float.TryParse(elem, out totalAmount);
                totalAmount = isSuccess ? totalAmount : -1;
            }

            return totalAmount;
        }
    }
}
