using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VineBasementHelpers.Models.VineModels.GET
{
    public class SearchVines
    {
        public string VineName { get; set; }
        public string VineColor { get; set; }
        public string VineType { get; set; }
        public string VineyardName { get; set; }
        public int YearOfBottling { get; set; }
        public decimal AlcoholPercentage { get; set; }
        public decimal Acidity { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal PurchasePrice { get; set; }
        public int AmountOfPurchasedBottles { get; set; }
        public int AmountOfOwnedBottles { get; set; }
    }
}
