using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VineBasementHelpers.Models.VineModels.GET
{
    public class GetAllVines
    {
        [Display(Name = "Identyfikator wina")]
        public string VineId { get; set; }

        [Display(Name ="Nazwa wina")]
        public string VineName { get; set; }
        
        [Display(Name = "Kolor wina")]
        public string VineColor { get; set; }
        
        [Display(Name = "Typ wina")]
        public string VineType { get; set; }
        
        [Display(Name = "Nazwa winnicy")]
        public string VineyardName { get; set; }

        [Display(Name = "Rok butelkowania")]
        public int YearOfBottling { get; set; }
        
        [Display(Name = "Procent alkoholu")]
        public decimal AlcoholPercentage { get; set; }
        
        [Display(Name = "Kwasowość")] 
        public decimal Acidity { get; set; }
        
        [Display(Name = "Data zakupu")] 
        public DateTime PurchaseDate { get; set; }
        
        [Display(Name = "Cena zakupu")] 
        public decimal PurchasePrice { get; set; }
        
        [Display(Name = "Liczba zakupionych butelek")] 
        public int AmountOfPurchasedBottles { get; set; }
        
        [Display(Name = "Liczba posiadanych butelek")] 
        public int AmountOfOwnedBottles { get; set; }
    }
}
