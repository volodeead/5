using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Product
{
    double money;
    string name;


    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {

            if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty.");
            }

            this.name = value;
        }
    }
    public double Money
    {
        get
        {
            return this.money;
        }
        set
        {
            this.money = value;
        }
    }
    public Product(string name, double money)
    {
        this.Money = money;
        this.Name = name;
    }
}
class Person
{
    double money;
    string name;
    public List<Product> bag = new List<Product>();

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {

            if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty.");
            }

            this.name = value;
        }
    }
    public double Money
    {
        get
        {
            return this.money;
        }
        set
        {
            this.money = value;
        }
    }
    public Person(string name , double money)
    {
        this.Money = money;
        this.Name = name;
    }

    public void AddItem(Product NewItem)
    {
        if ((money - NewItem.Money) < 0)
        {            
            throw new ArgumentException($"Dont can by {NewItem.Name}");
            
        }

        Console.WriteLine($"{this.Name} bought {NewItem.Name} ");

        bag.Add(NewItem);
        money -= NewItem.Money;
    }
}

class Program
    {
        static void Main(string[] args)
        {
        int item;
        int N;

        Console.WriteLine();

        Console.WriteLine("\nInput number of people: \n");
        N = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        Console.WriteLine("\nInput number of products: \n");
        item = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        double money;
        string name;

        List<Person> people = new List<Person>();
        List<Product> produc = new List<Product>();

        for (int i = 0; i < N; i++)
        {
            try
            {

                money = Convert.ToDouble(Console.ReadLine());
                name = Console.ReadLine();

                people.Add(new Person(name, money));
                money = 0;
                name = "";

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        Console.WriteLine("\n End of N insert \n");

        for (int i = 0; i < item; i++)
        {
            try
            {

                money = Convert.ToDouble(Console.ReadLine());
                name = Console.ReadLine();

                produc.Add(new Product(name, money));
                money = 0;
                name = "";

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        Console.WriteLine("\n End of Product insert \n");

        name = Console.ReadLine();
        string name2;

        while(name != "End")
        {
            try
            {
                for (int i = 0; i < people.Count; i++)
                {
                    if (name == people[i].Name)
                    {
                        name2 = Console.ReadLine();

                        for (int j = 0; j < produc.Count; j++)
                        {
                            if (name2 == produc[j].Name)
                            {
                                try
                                {
                                    people[i].AddItem(produc[j]);
                                }
                                catch (ArgumentException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    continue;
                                }
                                
                            }
                        }

                    }
                }
                
            }            
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                continue;
            }
            name = Console.ReadLine();
        }

        for(int i=0; i<people.Count; i++)
        {
            Console.WriteLine($"\n {people[i].Name} - ");
            for(int j=0; j < people[i].bag.Count; j++)
            {
                Console.Write($" {people[i].bag[j].Name} ");
            }
        }


        Console.ReadLine();

    }
}

