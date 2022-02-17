using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OBILET.WebApp.Models
{
    public class ResponseData : IDisposable
    {
        public string status { get; set; }
        public object data { get; set; }
        public string message { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
