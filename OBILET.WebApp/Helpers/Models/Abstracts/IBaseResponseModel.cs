using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OBILET.WebApp.Helpers.Models.Abstracts
{
    public interface IBaseResponseModel : IDisposable
    {
        public string Status { get; set; }

        public string Message { get; set; }

        public string UserMessage { get; set; }

        public string ApiRequestId { get; set; }

        public string Controller { get; set; }
    }
}
