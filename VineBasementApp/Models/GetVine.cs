namespace VineBasementApp.Models
{
    public class GetVine
    {
        public int VineId { get; set; }
        public string VineName { get; set; }
        public string VineColor { get; set; }
        public string VineType { get; set; }

        //klucz obcy
        public int VineyardId { get; set; }
        public DateTime YearOfBottling { get; set; }
        public float AlcoholPercentage { get; set; }
        public float Acidity { get; set; }
        public DateTime PurchaseDate { get; set; }
        public float PurchasePrice { get; set; }

        public int AmountOfPurchasedBottles { get; set; }
        public int AmountOfOwnedBottles { get; set; }
    }
}
