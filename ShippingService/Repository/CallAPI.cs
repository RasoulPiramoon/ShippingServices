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
    public class CallAPI : ICallApi
    {
        private readonly HttpClient httpClient;

        public CallAPI(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<float> CallAsJson(string path, string data)
        {
            float totalAmount = 0;
            try
            {
                var stringData = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(path, stringData);
                if (!response.IsSuccessStatusCode)
                    totalAmount = -1;
                else
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var isSuccess = float.TryParse(result, out totalAmount);
                    totalAmount = isSuccess ? totalAmount : -1;
                }
            }
            catch (Exception ex)
            {
                //log error
                totalAmount = -1;
            }

            return totalAmount;
        }

        public async Task<float> CallAsXml(string path, string xmlData)
        {
            float totalAmount = 0;
            try
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                var stringData = new StringContent(xmlData, Encoding.UTF8, "application/xml");
                var response = await httpClient.PostAsync(path, stringData);
                if (!response.IsSuccessStatusCode)
                    totalAmount = -1;
                else
                {
                    var reg = await response.Content.ReadAsStringAsync();
                    XDocument xdoc = XDocument.Parse(await response.Content.ReadAsStringAsync());
                    var elem = ((System.Xml.Linq.XElement)xdoc.FirstNode).Value;
                    var isSuccess = float.TryParse(elem, out totalAmount);
                    totalAmount = isSuccess ? totalAmount : -1;
                }
            }
            catch (Exception ex)
            {
                //log error
                totalAmount = -1;
            }
            return totalAmount;
        }
    }
}
