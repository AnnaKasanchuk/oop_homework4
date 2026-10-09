using System;

namespace Task5
{
    public class Product
    {
        public decimal Price { get; set; }
        public string OriginCountry { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateTime PackagingDate { get; set; }
        public string Description { get; set; } = string.Empty;

        public virtual string ProductType => "General";
        public virtual string SpecificDetails => $"{OriginCountry}";
    }

    public class FoodProduct : Product
    {
        public DateTime ExpirationDate { get; set; }
        public int Quantity { get; set; }
        public string MeasurementUnit { get; set; } = string.Empty;

        public override string ProductType => "Food";
        public override string SpecificDetails => $"Exp: {ExpirationDate:d} | {Quantity} {MeasurementUnit}";
    }

    public class Book : Product
    {
        public int PageCount { get; set; }
        public string Publisher { get; set; } = string.Empty;
        public string Authors { get; set; } = string.Empty;

        public override string ProductType => "Book";
        public override string SpecificDetails => $"{Publisher} | {PageCount} p. | {Authors}";
    }
}