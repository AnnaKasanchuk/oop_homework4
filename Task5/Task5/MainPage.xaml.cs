using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace Task5
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Product> Inventory { get; set; }

        public MainPage()
        {
            InitializeComponent();

            // Використовуємо collection expression для ініціалізації
            Inventory = 
            [
                new FoodProduct
                {
                    Name = "Apples",
                    Price = 35.50m,
                    OriginCountry = "Ukraine",
                    PackagingDate = DateTime.Now.AddDays(-2),
                    Description = "Fresh red apples",
                    ExpirationDate = DateTime.Now.AddDays(14),
                    Quantity = 50,
                    MeasurementUnit = "kg"
                },
                new Book
                {
                    Name = "C# 12 in a Nutshell",
                    Price = 1200.00m,
                    OriginCountry = "USA",
                    PackagingDate = DateTime.Now.AddMonths(-1),
                    Description = "Definitive reference",
                    PageCount = 1050,
                    Publisher = "O'Reilly",
                    Authors = "Joseph Albahari"
                }
            ];

            ProductsGrid.ItemsSource = Inventory;
        }

        private void OnAddProductClicked(object sender, EventArgs e)
        {
            Random random = new Random();
            int randomChoice = random.Next(1, 4);

            Product newProduct;

            switch (randomChoice)
            {
                case 1:
                    newProduct = new FoodProduct
                    {
                        Name = "Milk",
                        Price = 42.00m,
                        OriginCountry = "Ukraine",
                        PackagingDate = DateTime.Now,
                        Description = "Whole milk 2.5%",
                        ExpirationDate = DateTime.Now.AddDays(7),
                        Quantity = 20,
                        MeasurementUnit = "L"
                    };
                    break;
                case 2:
                    newProduct = new FoodProduct
                    {
                        Name = "Bread",
                        Price = 25.00m,
                        OriginCountry = "Ukraine",
                        PackagingDate = DateTime.Now,
                        Description = "Fresh white bread",
                        ExpirationDate = DateTime.Now.AddDays(3),
                        Quantity = 40,
                        MeasurementUnit = "pcs"
                    };
                    break;
                default:
                    newProduct = new Book
                    {
                        Name = "Harry Potter",
                        Price = 450.00m,
                        OriginCountry = "UK",
                        PackagingDate = DateTime.Now,
                        Description = "Fantasy novel",
                        PageCount = 350,
                        Publisher = "Bloomsbury",
                        Authors = "J.K. Rowling"
                    };
                    break;
            }

            Inventory.Add(newProduct);
        }

        private void OnDeleteProductClicked(object sender, EventArgs e)
        {
            if (ProductsGrid.SelectedItem is Product selectedProduct)
            {
                Inventory.Remove(selectedProduct);
                ProductsGrid.SelectedItem = null;
            }
        }
    }
}