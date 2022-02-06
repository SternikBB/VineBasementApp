using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Index(nameof(VineName), IsUnique = true)]
    public class Vine
    {
        [Key]
        public int VineId { get; set; }
        [Required]
        public string VineName { get; set; }
        [Required]
        public string VineColor { get; set; }
        [Required]
        public string VineType { get; set; }

        //klucz obcy
        public int VineyardId { get; set; }
        public Vineyard Vineyard { get; set; }
        [Required]
        public int YearOfBottling { get; set; }
        [Required]
        public decimal AlcoholPercentage { get; set; }
        [Required]
        public decimal Acidity { get; set; }
        [Required]
        public DateTime PurchaseDate { get; set; }
        [Required]
        public decimal PurchasePrice { get; set; }
        [Required]
        public int AmountOfPurchasedBottles { get; set; }
        [Required]
        public int AmountOfOwnedBottles { get; set; }
    }
}
