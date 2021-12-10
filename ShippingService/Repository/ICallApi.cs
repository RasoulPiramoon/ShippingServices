using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.Repository
{
    public interface ICallApi
    {
        Task<float> CallAsJson(string path, string data);
        Task<float> CallAsXml(string path, string data);
    }
}
