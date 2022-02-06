using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Index(nameof(VineyardName), IsUnique = true)]
    public class Vineyard
    {
        [Key]
        public int VineyardId { get; set; }
        [Required]
        public string VineyardName { get; set; }
        [Required]
        public string VineyardCity { get; set; }
        [Required]
        public string VineyardRegion { get; set; }
        [Required]
        public string VineyardCountry { get; set; }
        [Required]
        public string VineyardYearOfFoundation { get; set; }

        public ICollection<Vine> Vines { get; set; }

    }
}
