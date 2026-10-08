using System;

namespace GeographicInterfaceApp
{
    public interface IGeographicObject
    {
        double X { get; set; }
        double Y { get; set; }
        string Name { get; set; }
        string Description { get; set; }

        void GetInfo();
    }

    public class River : IGeographicObject
    {
        public double X { get; set; }
        public double Y { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public double FlowSpeed { get; set; }
        public double TotalLength { get; set; }

        public void GetInfo()
        {
            Console.WriteLine($"Object: {Name} | Coordinates: ({X}; {Y}) | Description: {Description}");
            Console.WriteLine($"Flow Speed: {FlowSpeed} cm/s, Total Length: {TotalLength} km");
        }
    }

    public class Mountain : IGeographicObject
    {
        public double X { get; set; }
        public double Y { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public double HighestPoint { get; set; }

        public void GetInfo()
        {
            Console.WriteLine($"Object: {Name} | Coordinates: ({X}; {Y}) | Description: {Description}");
            Console.WriteLine($"Highest Point: {HighestPoint} m");
        }
    }

    class Program
    {
        static void Main()
        {
            IGeographicObject river = new River
            {
                X = 46.4952,
                Y = 31.9930,
                Name = "Southern Bug",
                Description = "A river located in southwestern Ukraine",
                FlowSpeed = 45.0,
                TotalLength = 806.0
            };

            IGeographicObject mountain = new Mountain
            {
                X = 48.16,
                Y = 24.5,
                Name = "Pip Ivan",
                Description = "One of the highest peaks of the Chornohora range",
                HighestPoint = 2028.0
            };

            river.GetInfo();
            Console.WriteLine(new string('-', 30));
            mountain.GetInfo();
        }
    }
}