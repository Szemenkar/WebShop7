namespace e_commerce_project;

public class Cart
{

    public static List<string> shoppingCart = new();

    public static void AddToCart()
    {
        Console.Clear();
        Product.Get();
        foreach (var item in Product.list)
        {
            string[] separateItems = item.Split(":");
            Console.WriteLine($"{separateItems[0]} - {separateItems[1]}");
        }
        Console.WriteLine("-------------------------------");
        bool searchingForItems = true;
        Console.WriteLine("\n1. Add products to cart\n2. Go back to menu");
        string? menuInput = Console.ReadLine();

        if (menuInput == "1")
        {
            Console.Clear();
            Product.ShowAll();
            while (searchingForItems)
            {
                Console.WriteLine("---------------------------------------");
                Console.Write("\nType which product you would like to add to your cart: ");
                bool choosingItem = true;
                string? orderInput = Console.ReadLine();
                while (choosingItem)
                {
                    if (int.TryParse(orderInput, out int selectedIndex) && selectedIndex >= 1 && selectedIndex <= Product.list.Count)
                    {
                        string addedProduct = Product.list[selectedIndex - 1];
                        Console.WriteLine("\nYou've succesfully added that item to your cart!");
                        shoppingCart.Add(addedProduct);
                        Console.WriteLine("\n--------------------------------------");
                        Console.WriteLine("These items are currently in your shopping cart:");
                        foreach (string item in shoppingCart)
                        {
                            string[] items = item.Split(":");
                            Console.WriteLine($"{items[0]} ({items[1]})");
                        }
                        Console.WriteLine("--------------------------------------");
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
                    string? input = Console.ReadLine().ToLower();
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
            Menus.CustomerMenu();
        }
    }

    public static void RemoveFromCart()
    {
        Console.Clear();

        bool removeItem = true;
        bool showItem = true;
        while (showItem && shoppingCart.Count >= 1)
        {
            if (shoppingCart.Count >= 1)
            {
                int count = 1;
                Console.WriteLine("These are the products in your shopping cart: ");
                foreach (string item in shoppingCart)
                {
                    string[] items = item.Split(":");
                    Console.WriteLine($"{count}. {items[0]} ({items[1]})");
                    count++;
                }
                showItem = false;
                removeItem = true;
            }
            while (removeItem && shoppingCart.Count >= 1)
            {
                Console.Write("\nType which of the products you would like to remove from the cart: ");
                string? removeInput = Console.ReadLine();
                if (int.TryParse(removeInput, out int selectedIndex) && selectedIndex >= 1 && selectedIndex <= shoppingCart.Count)
                {
                    string? removedProduct = shoppingCart[selectedIndex - 1];
                    shoppingCart.Remove(removedProduct);
                    int index = removedProduct.IndexOf(":");
                    string temp = removedProduct.Substring(0, index);
                    Console.Clear();
                    Console.WriteLine("You've removed 1 " + temp + " from your cart.");
                    Console.WriteLine("-------------------------------------------------");
                    removeItem = false;
                    showItem = true;
                }
                else
                {
                    Console.Write("\nInvalid input. Type one of the options above.\n");
                }
            }
        }

        if (shoppingCart.Count == 0)
        {
            Console.WriteLine("You don't have any items in your shopping cart\nPress any key to continue.");
            Console.ReadKey();
        }
    }

    public static void ViewCart()
    {
        bool viewing = true;
        if (shoppingCart.Count == 0)
        {
            Console.WriteLine("Your shopping cart is empty.\nPress any key to continue");
            Console.ReadKey();
            viewing = false;
        }
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
            Console.Write("\nPress any key to continue");
            Console.ReadKey();
            break;
        }
    }
}