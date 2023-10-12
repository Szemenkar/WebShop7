class Program
{
    static List<Product> products = new List<Product>();
    static List<Product> order = new List<Product>();

    static void Main(string[] args)
    {
        LoadProducts();
        BuyProducts();
        DisplayOrder();
    }

    static void LoadProducts()
    {
        string[] lines = File.ReadAllLines("../../../products.txt");
        products = new List<Product>();

        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            if (parts.Length == 2 && double.TryParse(parts[1], out double price))
            {
                products.Add(new Product(parts[0], price));
            }
        }
    }

    static void BuyProducts()
    {
        Console.WriteLine("Tillgängliga Produkter:");
        for (int i = 0; i < products.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {products[i]}");
        }

        while (true)
        {
            Console.Write("Ange produktnummer (Ange 0 för att slutföra): ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if (choice == 0)
                {
                    break;
                }
                else if (choice > 0 && choice <= products.Count)
                {
                    order.Add(products[choice - 1]);
                    Console.WriteLine($"Du har lagt {products[choice - 1].Name} - {products[choice - 1].Price} till din beställning.");
                }
                else
                {
                    Console.WriteLine("Fel. Vänligen ange ett giltigt nummer.");
                }
            }
            else
            {
                Console.WriteLine("Fel. Vänligen ange ett nummer.");
            }
        }
    }

    static void DisplayOrder()
    {
        Console.WriteLine("Din beställning:");
        double total = 0;
        for (int i = 0; i < order.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {order[i]}");
            total += order[i].Price;
        }

        Console.WriteLine($"Totala priset: {total}");

        Console.WriteLine("Ange 'r' för att ta bort produkter, eller tryck Enter för att avsluta: ");
        string input = Console.ReadLine().Trim().ToUpper();

        if (input == "R")
        {
            RemoveProducts();
            total = 0;

            for (int i = 0; i < order.Count; i++)
            {
                total += order[i].Price;
            }
        }

        Console.WriteLine($"Uppdaterat totalpris: {total}");
    }

    static void RemoveProducts()
    {
        while (true)
        {
            Console.WriteLine("Din beställning:");
            for (int i = 0; i < order.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {order[i]}");
            }

            Console.Write("Ange produktnummer du vill ta bort (Ange 0 för att avsluta): ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if (choice == 0)
                {
                    break;
                }
                else if (choice > 0 && choice <= order.Count)
                {
                    Console.WriteLine($"Du tog bort {order[choice - 1].Name} från din beställning.");
                    order.RemoveAt(choice - 1);
                }
                else
                {
                    Console.WriteLine("Fel. Vänligen ange ett giltigt nummer.");
                }
            }
            else
            {
                Console.WriteLine("Fel. Vänligen ange ett nummer.");
            }
        }
    }

    class Product
    {
        public string Name { get; }
        public double Price { get; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Name} - {Price}";
        }
    }
}

