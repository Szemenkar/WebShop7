namespace e_commerce_project;
public class Checkout
{
    public static List<string> order = new();
    public static double total = 0;

    public static void DisplayOrder()
    {

        Console.Clear();
        Console.WriteLine("***********");
        Console.WriteLine("Your order:");
        Console.WriteLine("***********");
        Cart.ViewCart();
        Console.WriteLine();

        order = Cart.shoppingCart;

        foreach (var product in order)
        {
            string[] prices = product.Split("$");

            if (double.TryParse(prices[1], out double c))
            {
                total += c;
            }
            else
            {
                Console.WriteLine("Product price not found");
            }
        }
        Console.WriteLine("Order total: " + Math.Round(total, 2));

        Console.WriteLine("1. Checkout\n2. Cancel Order");

        switch (Console.ReadLine())
        {
            case "1":
                Console.Clear();
                Console.WriteLine("Your order has been completed and will be delivered in two minutes");
                Save();
                Cart.shoppingCart.Clear();
                total = 0;
                Console.ReadKey();
                break;
            case "2":
                break;
            default: Console.WriteLine("Invalid input");
                break;

        }
    }

    public static void Save()
    {
        File.ReadAllLines($"../../../userdata/{Customer.UserList[0].Username}.txt");
        StreamWriter write = File.AppendText($"../../../userdata/{Customer.UserList[0].Username}.txt");

        write.WriteLine($"\n{DateTime.Now.ToString()}\n\nCart:\n*****************************\n");
        
        for (int i = 0; i < Cart.shoppingCart.Count; i++)
        {
            write.WriteLine(Cart.shoppingCart[i]);
        }

        write.WriteLine($"\n*****************************\nTotal sum: ${Math.Round(total, 2)}\n");

        write.Close();
    }
}
