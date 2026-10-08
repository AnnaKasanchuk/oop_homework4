using System;

namespace GeographicAbstractApp
{
    public abstract class GeographicObject
    {
        public double X { get; set; }
        public double Y { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public virtual void GetInfo()
        {
            Console.WriteLine($"Object: {Name} | Coordinates: ({X}; {Y}) | Description: {Description}");
        }
    }

    public class River : GeographicObject
    {
        public double FlowSpeed { get; set; }
        public double TotalLength { get; set; }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"Flow Speed: {FlowSpeed} cm/s, Total Length: {TotalLength} km");
        }
    }

    public class Mountain : GeographicObject
    {
        public double HighestPoint { get; set; }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"Highest Point: {HighestPoint} m");
        }
    }

    class Program
    {
        static void Main()
        {
            River dnipro = new River
            {
                X = 48.4647,
                Y = 35.0461,
                Name = "Dnipro",
                Description = "The longest river in Ukraine",
                FlowSpeed = 50.0,
                TotalLength = 2201.0
            };

            Mountain hoverla = new Mountain
            {
                X = 48.1602,
                Y = 24.5000,
                Name = "Hoverla",
                Description = "The highest peak of the Ukrainian Carpathians",
                HighestPoint = 2061.0
            };

            dnipro.GetInfo();
            Console.WriteLine(new string('-', 30));
            hoverla.GetInfo();
        }
    }
}