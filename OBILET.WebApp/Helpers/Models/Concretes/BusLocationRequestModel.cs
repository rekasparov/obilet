using Newtonsoft.Json;
using OBILET.WebApp.Helpers.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OBILET.WebApp.Helpers.Models.Concretes
{
    public class BusLocationRequestModel: BaseRequestModel
    {
        public string Data { get; set; }
    }
}
