namespace e_commerce_project;

public class Cart
{

    public static List<string> shoppingCart = new();

    public static void AddToCart()
    {
        Console.Clear();
        Product.ShowAll();

        bool searchingForItems = true;
        Console.WriteLine("1. Add products to cart\n2. Go back to menu");
        string menuInput = Console.ReadLine();

        if (menuInput == "1")
        {
            while (searchingForItems)
            {
                Console.Write("\nType which product you would like to add to your cart: ");
                bool choosingItem = true;
                string orderInput = Console.ReadLine();
                while (choosingItem)
                {
                    if (int.TryParse(orderInput, out int selectedIndex) && selectedIndex >= 1 && selectedIndex <= Product.list.Count)
                    {
                        string addedProduct = Product.list[selectedIndex - 1];
                        Console.WriteLine("\nYou've succesfully added that item to your cart!");
                        shoppingCart.Add(addedProduct);
                        Console.WriteLine("\nThese items are currently in your shopping cart:");
                        foreach (string item in shoppingCart)
                        {
                            string[] items = item.Split(":");
                            Console.WriteLine($"{items[0]} ({items[1]})");
                        }
                        choosingItem = false;
                    }
                    else
                    {
                        Console.Write("You must write one of the options above: ");
                        orderInput = Console.ReadLine();
                    }
                }

                bool newItem = true;

                while (newItem)
                {
                    Console.WriteLine("\nWould you like to add more items to the cart? Y/N");
                    string input = Console.ReadLine().ToLower();
                    if (input == "y")
                    {
                        Console.Clear();
                        Product.ShowAll();
                        newItem = false;
                    }
                    else if (input == "n")
                    {
                        searchingForItems = false;
                        newItem = false;
                    }
                    else
                    {
                        Console.WriteLine("Type 'Y' or 'N'");
                    }
                }
            }
        }
        else if (menuInput == "2")
        {
            Customer.CustomerMenu();
        }
    }

    public static void RemoveFromCart()
    {
        Console.Clear();

        bool removeItemQuestion = true;
        bool removeItem = true;

        while (removeItemQuestion && shoppingCart.Count >= 1)
        {
            Console.WriteLine("Would you like to remove an item from the cart? Y/N");
            string input = Console.ReadLine().ToLower();
            if (input == "y" && shoppingCart.Count >= 1)
            {
                int count = 1;
                Console.Clear();
                Console.WriteLine("These are the products in your shopping cart: ");
                foreach (string item in shoppingCart)
                {
                    string[] items = item.Split(":");
                    Console.WriteLine($"{count}. {items[0]} ({items[1]})");
                    count++;
                }
                removeItemQuestion = false;
                removeItem = true;
            }
            else if (input == "n")
            {
                removeItemQuestion = false;
                removeItem = false;
            }
            else
            {
                Console.WriteLine("Type 'Y' or 'N'");
                removeItem = false;
            }

            while (removeItem && shoppingCart.Count >= 1)
            {
                Console.Write("\nType which of the products you would like to remove from the cart: ");
                string removeInput = Console.ReadLine();
                if (int.TryParse(removeInput, out int selectedIndex) && selectedIndex >= 1 && selectedIndex <= shoppingCart.Count)
                {
                    string removedProduct = shoppingCart[selectedIndex - 1];
                    shoppingCart.Remove(removedProduct);
                    int index = removedProduct.IndexOf(":");
                    string temp = removedProduct.Substring(0, index);
                    Console.WriteLine("\nYou've removed 1 " + temp + " from your cart.");
                    removeItem = false;
                    removeItemQuestion = true;
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }

            while (shoppingCart.Count == 0)
            {
                Console.WriteLine("\nYou don't have any items in your shopping cart\nPress any key to continue.");
                Console.ReadKey();
                break;
            }
        }
    }

    public static void ViewCart()
    {
        bool viewing = true;
        while (viewing)
        {
            Console.Clear();
            int count = 1;
            Console.WriteLine("These items are in your shopping cart: ");
            foreach (string item in shoppingCart)
            {
                string[] items = item.Split(":");
                Console.WriteLine($"{count}. {items[0]}");
                count++;
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            break;
        }
    }
}