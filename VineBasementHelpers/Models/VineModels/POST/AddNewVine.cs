using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VineBasementHelpers.Models.VineModels.POST
{
    public class AddNewVine
    {
        [Required(ErrorMessage = "Nazwa wina jest wymagana!")]
        [StringLength(50, ErrorMessage = "Nazwa wina nie może być dłuższa niż 50 znaków")]
        public string VineName { get; set; }

        [Required(ErrorMessage = "Kolor wina jest wymagane!")]
        [StringLength(20, ErrorMessage = "Kolor wina nie może być dłuższy niż 20 znaków")]
        public string VineColor { get; set; }

        [Required(ErrorMessage = "Typ wina jest wymagana!")]
        [StringLength(20, ErrorMessage = "Typwina nie może być dłuższy niż 20 znaków")]
        public string VineType { get; set; }

        [Required(ErrorMessage = "Podanie winiarni jest wymagane!")]
        public int VineyardID { get; set; }

        [Required(ErrorMessage = "Rok zabutelkowania jest wymagany!")]
        [Range(1800, 2022)]
        public int YearOfBottling { get; set; }

        [Required(ErrorMessage = "Zawartość alkoholu jest wymagana!")]
        public decimal AlcoholPercentage { get; set; }

        [Required(ErrorMessage = "Kwasowość jest wymagana!")]
        public decimal Acidity { get; set; }

        [Required(ErrorMessage = "Data zakupu jest wymagana!")]
        [BindProperty, DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }

        [Required(ErrorMessage = "Cena wina jest wymagana!")]
        [Range(0, 999999.99)]
        public decimal PurchasePrice { get; set; }

        [Required(ErrorMessage = "Podanie liczby zakupionych jest wymagane!")]
        public int AmountOfPurchasedBottles { get; set; }

        [Required(ErrorMessage = "Podanie liczby posiadanych butelek jest wymagane!")]
        public int AmountOfOwnedBottles { get; set; }
    }
}
