namespace e_commerce_project;
public class Checkout
{
    public static List<string> order = new();
    public static double total = 0;

    public static void DisplayOrder()
    {
        order = Cart.shoppingCart;
        Console.Clear();
        bool tryToDisplay = true;
        while (tryToDisplay)
        {
            if (order.Count == 0)
            {
                Console.WriteLine("You do not have any products in your cart.\nPlease add items before trying to checkout.");
                Console.ReadKey();
                break;
            }
            Console.WriteLine("Your order:");
            Console.WriteLine();

            foreach (var product in order)
            {
                string[] items = product.Split(":");
                Console.WriteLine($"{items[0]} ({items[1]})");
            }
            Console.WriteLine();
            Console.WriteLine("---------------------------------\n");

            foreach (var product in order)
            {
                string[] prices = product.Split("$");

                if (double.TryParse(prices[1], out double c))
                {
                    total += Math.Round(c, 2);
                }
                else
                {
                    Console.WriteLine("Product price not found");
                }
            }

            Console.WriteLine("Order total: $" + Math.Round(total, 2));
            Console.WriteLine();
            Console.WriteLine("---------------------------------\n");
            Console.WriteLine("\n1. Checkout\n2. Cancel Order");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Your order has been completed! Press any key to continue.");
                    Save();
                    Cart.shoppingCart.Clear();
                    total = 0;
                    Console.ReadKey();
                    tryToDisplay = false;
                    break;
                case "2":
                    total = 0;
                    tryToDisplay = false;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid input");
                    break;
            }
        }
    }

    public static void Save()
    {
        File.ReadAllLines($"userdata/{Customer.UserList[0].Username}.txt");
        StreamWriter write = File.AppendText($"userdata/{Customer.UserList[0].Username}.txt");

        write.WriteLine($"{DateTime.Now}\n\nCart:\n*****************************\n");

        for (int i = 0; i < Cart.shoppingCart.Count; i++)
        {
            write.WriteLine(Cart.shoppingCart[i]);
        }

        write.WriteLine($"\n*****************************\n\nTotal sum: ${Math.Round(total, 2)}\n");

        write.Close();
    }
}