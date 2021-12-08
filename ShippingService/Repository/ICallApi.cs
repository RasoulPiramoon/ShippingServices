using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.Repository
{
    public interface ICallApi
    {
        Task<float> Call();
        Task<float> Call2(string path, object data);
        Task<float> Call3(string path, object data);
    }
}
