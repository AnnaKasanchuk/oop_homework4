using System;

// 3. Add a new abstract class "Geographic Object"
public abstract class GeographicObject
{
    public double X { get; set; }
    public double Y { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public virtual void GetInformation()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Coordinates: ({X}, {Y})");
        Console.WriteLine($"Description: {Description}");
    }
}

// 4. Add "River" and "Mountain" classes that inherit from the abstract class
public class River : GeographicObject
{
    public double FlowSpeed { get; set; } // Flow speed in cm/s
    public double TotalLength { get; set; } // Total length

    public override void GetInformation()
    {
        base.GetInformation();
        Console.WriteLine($"Flow Speed: {FlowSpeed} cm/s");
        Console.WriteLine($"Total Length: {TotalLength}");
    }
}

public class Mountain : GeographicObject
{
    public double HighestPoint { get; set; } // Highest point

    public override void GetInformation()
    {
        base.GetInformation();
        Console.WriteLine($"Highest Point: {HighestPoint}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- Create a River ---");
        River userRiver = new River();
        
        Console.Write("Enter name: ");
        userRiver.Name = Console.ReadLine();
        
        Console.Write("Enter description: ");
        userRiver.Description = Console.ReadLine();
        
        Console.Write("Enter X coordinate: ");
        userRiver.X = Convert.ToDouble(Console.ReadLine());
        
        Console.Write("Enter Y coordinate: ");
        userRiver.Y = Convert.ToDouble(Console.ReadLine());
        
        Console.Write("Enter flow speed (cm/s): ");
        userRiver.FlowSpeed = Convert.ToDouble(Console.ReadLine());
        
        Console.Write("Enter total length: ");
        userRiver.TotalLength = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("\n--- Create a Mountain ---");
        Mountain userMountain = new Mountain();
        
        Console.Write("Enter name: ");
        userMountain.Name = Console.ReadLine();
        
        Console.Write("Enter description: ");
        userMountain.Description = Console.ReadLine();
        
        Console.Write("Enter X coordinate: ");
        userMountain.X = Convert.ToDouble(Console.ReadLine());
        
        Console.Write("Enter Y coordinate: ");
        userMountain.Y = Convert.ToDouble(Console.ReadLine());
        
        Console.Write("Enter highest point: ");
        userMountain.HighestPoint = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("\n--- River Information ---");
        userRiver.GetInformation();

        Console.WriteLine("\n--- Mountain Information ---");
        userMountain.GetInformation();
        
        Console.ReadLine();
    }
}