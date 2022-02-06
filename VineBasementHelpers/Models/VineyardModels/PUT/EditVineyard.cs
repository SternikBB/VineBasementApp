using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VineBasementHelpers.Models.VineyardModels.PUT
{
    public class EditVineyard
    {
        public int VineyardId { get; set; }

        [Required(ErrorMessage = "Nazwa winnicy jest wymagana!")]
        public string VineyardName { get; set; }

        [Required(ErrorMessage = "Nazwa miasta winnicy jest wymagana!")]
        public string VineyardCity { get; set; }

        [Required(ErrorMessage = "Nazwa regionu winnicy jest wymagana!")]
        public string VineyardRegion { get; set; }

        [Required(ErrorMessage = "Nazwa  kraju winnicy jest wymagana!")]
        public string VineyardCountry { get; set; }

        [Required(ErrorMessage = "Rok założenia winnicy jest wymagany!")]
        public string VineyardYearOfFoundation { get; set; }
    }
}
