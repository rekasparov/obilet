using System.Collections.Generic;
using static OBILET.WebApp.Helpers.Models.Concretes.BusLocationResponseModel;

namespace OBILET.WebApp.Models
{
    public class SearchResultModel
    {
        public bool incomplete_results { get => false; }
        public List<DataModel> items { get; set; }
        public int total_count { get; set; }
    }
}
