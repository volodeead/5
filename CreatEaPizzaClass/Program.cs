using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Dough
{
    private const int BaseCaloriesPerGram = 2;

    private static string[] allowedFlourTypes = {

        "White",
        "Wholegrain"
    };

    private static string[] allowedBakingTechniqueTypes = {

        "Crispy",
       "Chewy",
        "Homemade"
    };

    private string flourType;
    private string bakingTechnique;
    private int weight;

    public Dough(string flourType, string bakingTechnique, int weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }

    private string FlourType
    {
        get
        {
            return this.flourType;
        }

        set
        {
            if (!allowedFlourTypes.Any(ft => ft==value))
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            this.flourType = value;
        }
    }

    private string BakingTechnique
    {
        get
        {
            return this.bakingTechnique;
        }

        set
        {
            if (!allowedBakingTechniqueTypes.Any(ft => ft == value))
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            this.bakingTechnique = value;
        }
    }

    private int Weight
    {
        get
        {
            return this.weight;
        }

        set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }

            this.weight = value;
        }
    }

    public double Calories()
    {
        
        var ftModifier = 0.0;

        if (this.FlourType == "White")
        {
            ftModifier = 1.5;
        }
        if (this.FlourType == "Wholegrain")
        {
            ftModifier = 1.0;
        }


        var btModifier = 0.0;

        if (this.BakingTechnique == "Crispy")
        {
            btModifier =  0.9;
        }
        if (this.BakingTechnique == "Chewy")
        {
            btModifier = 1.1;
        }
        if (this.BakingTechnique == "Homemade")
        {
            btModifier = 1.0;
        }
        

        return BaseCaloriesPerGram * ftModifier * btModifier * this.Weight;
    }
}
public class Topping
{
    private const int BaseCaloriesPerGram = 2;

    private static string[] allowedToppingTypes = {

        "Meat",
        "Veggies",
        "Cheese",
        "Sauce"
    };

    private string toppingType;
    private int weight;

    public Topping(string toppingType, int weight)
    {
        this.ToppingType = toppingType;
        this.Weight = weight;
    }

    private string ToppingType
    {

        get
        {
            return this.toppingType;
        }

        set
        {
            if (!allowedToppingTypes.Any(tt => tt == value))
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }

            this.toppingType = value;
        }
    }

    private int Weight
    {
        get
        {
            return this.weight;
        }

        set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{this.ToppingType} weight should be in the range [1..50].");
            }

            this.weight = value;
        }
    }

    public double Calories()
    {

        var ttModifier = 0.0;

        if (this.ToppingType == "Meat")
        {
            ttModifier = 1.2;
        }
        if (this.ToppingType == "Veggies")
        {
            ttModifier = 0.8;
        }
        if (this.ToppingType == "Cheese")
        {
            ttModifier = 1.1;
        }
        if (this.ToppingType == "Sauce")
        {
            ttModifier = 0.9;
        }

        return BaseCaloriesPerGram * ttModifier * this.Weight;
    }
}
public class Pizza
{
    private string name;
    private Dough dough;
    private List<Topping> toppings;

    public Pizza(string name)
    {
        this.Name = name;
        this.toppings = new List<Topping>();
    }

    private string Name
    {
        get
        {
            return this.name;
        }

        set
        {
            if (value.Length < 1 || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }

            this.name = value;
        }
    }

    public Dough Dough
    {
        set
        {
            this.dough = value;
        }
    }

    public void AddTopping(Topping topping)
    {
        if (this.toppings.Count == 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }

        this.toppings.Add(topping);
    }

    public double Calories()
    {
        double sum = 0;
        sum += this.dough.Calories();
        this.toppings.ForEach(t => sum += t.Calories());

        return sum;
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.Calories()} Calories.";
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var tokens = Console.ReadLine().Split();
            Pizza pizza = new Pizza(tokens[1]);
            tokens = Console.ReadLine().Split();
            pizza.Dough = new Dough(tokens[1], tokens[2], int.Parse(tokens[3]));

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                tokens = command.Split();
                pizza.AddTopping(new Topping(tokens[1], int.Parse(tokens[2])));
            }

            Console.WriteLine(pizza);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadLine();
        }

        Console.ReadLine();
    }

}

