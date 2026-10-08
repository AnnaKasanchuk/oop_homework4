using System;
using System.Text;

namespace ConverterApp
{
    public class Converter
    {
        public decimal UsdRate { get; private set; } = 0m; 
        
        public decimal EurRate { get; private set; } = 0m;

        public Converter(decimal usdRate, decimal eurRate)
        {
            UsdRate = usdRate;
            EurRate = eurRate;
        }

        public decimal ConvertUahToUsd(decimal uahAmount)
        {
            return uahAmount / UsdRate;
        }

        public decimal ConvertUsdToUah(decimal usdAmount)
        {
            return usdAmount * UsdRate;
        }

        public decimal ConvertUahToEur(decimal uahAmount)
        {
            return uahAmount / EurRate;
        }

        public decimal ConvertEurToUah(decimal eurAmount)
        {
            return eurAmount * EurRate;
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Enter USD to UAH exchange rate: ");
            string usdInput = Console.ReadLine() ?? string.Empty;
            decimal usdRate = decimal.TryParse(usdInput, out decimal parsedUsd) ? parsedUsd : 41.5m;
            
            Console.Write("Enter EUR to UAH exchange rate: ");
            string eurInput = Console.ReadLine() ?? string.Empty;
            decimal eurRate = decimal.TryParse(eurInput, out decimal parsedEur) ? parsedEur : 45.2m;

            Converter converter = new Converter(usdRate, eurRate);

            bool isRunning = true; 

            while (isRunning)
            {
                Console.WriteLine("\n=== CURRENCY CONVERTER ===");
                Console.WriteLine("1. Convert UAH to USD");
                Console.WriteLine("2. Convert USD to UAH");
                Console.WriteLine("3. Convert UAH to EUR");
                Console.WriteLine("4. Convert EUR to UAH");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an action: ");

                string choice = Console.ReadLine() ?? string.Empty; 
                Console.WriteLine();

                bool isUahToUsd = choice == "1";
                bool isUsdToUah = choice == "2";
                bool isUahToEur = choice == "3";
                bool isEurToUah = choice == "4";
                bool isExit = choice == "0";

                if (isUahToUsd)
                {
                    Console.Write("Enter amount in UAH: ");
                    string amountInput = Console.ReadLine() ?? string.Empty;
                    
                    decimal amount = decimal.TryParse(amountInput, out decimal parsedAmount) ? parsedAmount : 0m;
                    
                    decimal result = converter.ConvertUahToUsd(amount);
                    
                    Console.WriteLine($"{amount} UAH = {result:F2} USD");
                }
                else if (isUsdToUah)
                {
                    Console.Write("Enter amount in USD: ");
                    string amountInput = Console.ReadLine() ?? string.Empty;
                    decimal amount = decimal.TryParse(amountInput, out decimal parsedAmount) ? parsedAmount : 0m;
                    
                    decimal result = converter.ConvertUsdToUah(amount);
                    
                    Console.WriteLine($"{amount} USD = {result:F2} UAH");
                }
                else if (isUahToEur)
                {
                    Console.Write("Enter amount in UAH: ");
                    string amountInput = Console.ReadLine() ?? string.Empty;
                    decimal amount = decimal.TryParse(amountInput, out decimal parsedAmount) ? parsedAmount : 0m;
                    
                    decimal result = converter.ConvertUahToEur(amount);
                    
                    Console.WriteLine($"{amount} UAH = {result:F2} EUR");
                }
                else if (isEurToUah)
                {
                    Console.Write("Enter amount in EUR: ");
                    string amountInput = Console.ReadLine() ?? string.Empty;
                    decimal amount = decimal.TryParse(amountInput, out decimal parsedAmount) ? parsedAmount : 0m;
                    
                    decimal result = converter.ConvertEurToUah(amount);
                    
                    Console.WriteLine($"{amount} EUR = {result:F2} UAH");
                }
                else if (isExit)
                {
                    isRunning = false;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }
    }
}