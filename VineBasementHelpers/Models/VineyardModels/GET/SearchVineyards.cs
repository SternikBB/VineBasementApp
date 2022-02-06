using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VineBasementHelpers.Models.VineyardModels.GET
{
    public class SearchVineyards
    {
        public string VineyardName { get; set; }
        public string VineyardCity { get; set; }
        public string VineyardRegion { get; set; }
        public string VineyardCountry { get; set; }
        public string VineyardYearOfFoundation { get; set; }
    }
}
