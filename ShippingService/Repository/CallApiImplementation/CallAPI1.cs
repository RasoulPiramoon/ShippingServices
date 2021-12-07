using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShippingService.Repository.CallApiImplementation
{
    public class CallAPI1 : ICallApi
    {
        public Task<float> Call()
        {
            throw new NotImplementedException();
        }

        public Task<float> Call2(string path, object data)
        {
            HttpClient client = new HttpClient();
            throw new NotImplementedException();
        }
    }
}
