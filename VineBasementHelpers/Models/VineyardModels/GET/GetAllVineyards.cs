using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VineBasementHelpers.Models.VineyardModels.GET
{
    public class GetAllVineyards
    {
        [Display(Name = "Identyfikator winnicy")]
        public int VineyardId { get; set; }

        [Display(Name = "Nazwa winnicy")]
        public string VineyardName { get; set; }

        [Display(Name = "Miasto winnicy")]
        public string VineyardCity { get; set; }

        [Display(Name = "Region winnicy")]
        public string VineyardRegion { get; set; }

        [Display(Name = "Kraj winnicy")]
        public string VineyardCountry { get; set; }

        [Display(Name = "Rok założenia winnicy")]
        public string VineyardYearOfFoundation { get; set; }
    }
}
