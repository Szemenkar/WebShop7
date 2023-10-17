namespace e_commerce_project;
public class Checkout
{
    public static List<string> order = new();
    public static void DisplayOrder()
    {
        Console.Clear();
        Console.WriteLine("***********");
        Console.WriteLine("Your order:");
        Console.WriteLine("***********");
        Cart.ViewCart();
        Console.WriteLine();

        double total = 0;

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
        Console.WriteLine("Order total: " + total);

        Console.WriteLine("1. Checkout\n2. Cancel Order");

        switch (Console.ReadLine())
        {
            case "1":
                Console.Clear();
                Console.WriteLine("Your order has been completed and will be delivered in two minutes");
                Console.ReadKey();
                break;
            case "2":
                break;

        }   
    }
}
