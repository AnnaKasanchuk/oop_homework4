using System;

// 6. Add a new interface "Geographic Object"
public interface IGeographicObject
{
    double X { get; set; }
    double Y { get; set; }
    string Name { get; set; }
    string Description { get; set; }

    void GetInformation();
}

// 7. Add "River" and "Mountain" classes that implement the interface
public class RiverImpl : IGeographicObject
{
    public double X { get; set; }
    public double Y { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public double FlowSpeed { get; set; }
    public double TotalLength { get; set; }

    public void GetInformation()
    {
        Console.WriteLine($"Name: {Name} (Interface Implementation)");
        Console.WriteLine($"Coordinates: ({X}, {Y})");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Flow Speed: {FlowSpeed} cm/s");
        Console.WriteLine($"Total Length: {TotalLength}");
    }
}

public class MountainImpl : IGeographicObject
{
    public double X { get; set; }
    public double Y { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public double HighestPoint { get; set; }

    public void GetInformation()
    {
        Console.WriteLine($"Name: {Name} (Interface Implementation)");
        Console.WriteLine($"Coordinates: ({X}, {Y})");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Highest Point: {HighestPoint}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- Create a River ---");
        IGeographicObject userRiver = new RiverImpl();
        
        Console.Write("Enter name: ");
        userRiver.Name = Console.ReadLine();
        
        Console.Write("Enter description: ");
        userRiver.Description = Console.ReadLine();
        
        Console.Write("Enter X coordinate: ");
        userRiver.X = Convert.ToDouble(Console.ReadLine());
        
        Console.Write("Enter Y coordinate: ");
        userRiver.Y = Convert.ToDouble(Console.ReadLine());
        
        // Для доступу до специфічних властивостей, яких немає в інтерфейсі, використовуємо приведення типів
        Console.Write("Enter flow speed (cm/s): ");
        ((RiverImpl)userRiver).FlowSpeed = Convert.ToDouble(Console.ReadLine());
        
        Console.Write("Enter total length: ");
        ((RiverImpl)userRiver).TotalLength = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("\n--- Create a Mountain ---");
        IGeographicObject userMountain = new MountainImpl();
        
        Console.Write("Enter name: ");
        userMountain.Name = Console.ReadLine();
        
        Console.Write("Enter description: ");
        userMountain.Description = Console.ReadLine();
        
        Console.Write("Enter X coordinate: ");
        userMountain.X = Convert.ToDouble(Console.ReadLine());
        
        Console.Write("Enter Y coordinate: ");
        userMountain.Y = Convert.ToDouble(Console.ReadLine());
        
        Console.Write("Enter highest point: ");
        ((MountainImpl)userMountain).HighestPoint = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("\n--- River Information ---");
        userRiver.GetInformation();

        Console.WriteLine("\n--- Mountain Information ---");
        userMountain.GetInformation();
        
        Console.ReadLine();
    }
}