using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        this.length = length;
        this.width = width;
        this.height = height;
    }

    public string GetSurfaceArea()
    {
        double surfaceArea = 2 * length * width + 2 * length * height + 2 * width * height;

        return $"Surface Area - {surfaceArea}";
    }

    public string GetLateralSurfaceArea()
    {
        double lateralSurfaceArea = 2 * length * height + 2 * width * height;

        return $"Lateral Surface Area - {lateralSurfaceArea}";
    }

    public string GetVolume()
    {
        double volume = length * width * height;

        return $"Volume - {volume}";
    }
}
class Program
{
    static void Main(string[] args)
    {
        double length = double.Parse(Console.ReadLine());
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        Box box = new Box(length, width, height);

        Console.WriteLine(box.GetSurfaceArea());
        Console.WriteLine(box.GetLateralSurfaceArea());
        Console.WriteLine(box.GetVolume());

        Console.ReadKey();
    }
}

