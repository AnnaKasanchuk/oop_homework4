using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Task4_Interface
{
    // 6. Interface "Geographic Object"
    public interface IGeographicObject
    {
        double CoordinateX { get; }
        double CoordinateY { get; }
        string Name { get; }
        string Description { get; }

        void GetInfo();
    }

    // 7. "River" and "Mountain" implement the interface
    public class River : IGeographicObject
    {
        public double CoordinateX { get; }
        public double CoordinateY { get; }
        public string Name { get; }
        public string Description { get; }
        public double FlowSpeed { get; }   // cm/s
        public double TotalLength { get; } // km

        public River(double x, double y, string name, string description,
                     double flowSpeed, double totalLength)
        {
            CoordinateX = x;
            CoordinateY = y;
            Name = name;
            Description = description;
            FlowSpeed = flowSpeed;
            TotalLength = totalLength;
        }

        public void GetInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Coordinates: ({CoordinateX}, {CoordinateY})");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Flow Speed: {FlowSpeed} cm/s");
            Console.WriteLine($"Total Length: {TotalLength} km");
        }
    }

    public class Mountain : IGeographicObject
    {
        public double CoordinateX { get; }
        public double CoordinateY { get; }
        public string Name { get; }
        public string Description { get; }
        public double HighestPoint { get; } // m

        public Mountain(double x, double y, string name, string description,
                        double highestPoint)
        {
            CoordinateX = x;
            CoordinateY = y;
            Name = name;
            Description = description;
            HighestPoint = highestPoint;
        }

        public void GetInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Coordinates: ({CoordinateX}, {CoordinateY})");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Highest Point: {HighestPoint} m");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            List<IGeographicObject> objects = new List<IGeographicObject>();
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add River");
                Console.WriteLine("2. Add Mountain");
                Console.WriteLine("3. Show all objects");
                Console.WriteLine("0. Exit");
                Console.Write("Select choice: ");

                string choice = (Console.ReadLine() ?? string.Empty).Trim();

                switch (choice)
                {
                    case "1":
                        AddRiver(objects);
                        break;
                    case "2":
                        AddMountain(objects);
                        break;
                    case "3":
                        ShowAllObjects(objects);
                        break;
                    case "0":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Error: Invalid choice.");
                        break;
                }
            }
        }

        private static void AddRiver(List<IGeographicObject> objects)
        {
            ReadCommonFields(out string name, out string description, out double x, out double y);
            double speed = ReadDouble("Enter flow speed (cm/s): ", true);
            double length = ReadDouble("Enter total length (km): ", true);

            objects.Add(new River(x, y, name, description, speed, length));
            Console.WriteLine($"River '{name}' added.");
        }

        private static void AddMountain(List<IGeographicObject> objects)
        {
            ReadCommonFields(out string name, out string description, out double x, out double y);
            double height = ReadDouble("Enter highest point (m): ", true);

            objects.Add(new Mountain(x, y, name, description, height));
            Console.WriteLine($"Mountain '{name}' added.");
        }

        private static void ShowAllObjects(List<IGeographicObject> objects)
        {
            if (objects.Count == 0)
            {
                Console.WriteLine("No objects available.");
                return;
            }

            for (int i = 0; i < objects.Count; i++)
            {
                Console.WriteLine($"\nObject {i + 1}");
                objects[i].GetInfo(); // call through the interface
            }
        }

        // Fields shared by every geographic object
        private static void ReadCommonFields(out string name, out string description,
                                             out double x, out double y)
        {
            Console.Write("Enter name: ");
            name = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter description: ");
            description = Console.ReadLine() ?? string.Empty;

            x = ReadDouble("Enter Coordinate X: ");
            y = ReadDouble("Enter Coordinate Y: ");
        }

        // Accepts both "27.98" and "27,98"; asks again only for this field
        private static double ReadDouble(string prompt, bool nonNegative = false)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = (Console.ReadLine() ?? string.Empty).Trim().Replace(',', '.');

                bool isNumber = double.TryParse(input, NumberStyles.Float,
                                                CultureInfo.InvariantCulture, out double value)
                                && !double.IsNaN(value) && !double.IsInfinity(value);

                if (!isNumber)
                {
                    Console.WriteLine("Error: enter a valid number.");
                }
                else if (nonNegative && value < 0)
                {
                    Console.WriteLine("Error: value cannot be negative.");
                }
                else
                {
                    return value;
                }
            }
        }
    }
}