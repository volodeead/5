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
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    private double Length
    {
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Length cannot be zero or negative.");
            }
            this.length = value;
        }
    }

    private double Width
    {
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Width cannot be zero or negative.");
            }
            this.width = value;
        }
    }

    private double Height
    {
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Height cannot be zero or negative.");
            }
            this.height = value;
        }
    }

    public string GetSurfaceArea()
    {
        double surfaceArea = 2 * length * width + 2 * length * height + 2 * width * height;

        return $"Surface Area - {surfaceArea:F2}";
    }

    public string GetLateralSurfaceArea()
    {
        double lateralSurfaceArea = 2 * length * height + 2 * width * height;

        return $"Lateral Surface Area - {lateralSurfaceArea:F2}";
    }

    public string GetVolume()
    {
        double volume = length * width * height;

        return $"Volume - {volume:F2}";
    }
}
class Program
{
    static void Main(string[] args)
    {
        double length = double.Parse(Console.ReadLine());
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        try
        {
            Box box = new Box(length, width, height);

            Console.WriteLine(box.GetSurfaceArea());
            Console.WriteLine(box.GetLateralSurfaceArea());
            Console.WriteLine(box.GetVolume());
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.ReadKey();
    }
}

