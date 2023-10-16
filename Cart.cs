using System;

namespace e_commerce_project;

public class Cart
{

    public static List<string> shoppingCart = new();

    public static void AddToCart()
    {
        Console.Clear();
        Product.ShowAll();
        List<string> productList = Product.list;

        bool searchingForItems = true;

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

    /*
    public static void RemoveFromCart()
    {
        Console.Clear();
        List<string> shoppingCart = AddToCart();

        bool removeItem = true;

        while (removeItem)
        {
            Console.WriteLine("\nWould you like to remove an item from the cart? Y/N");
            string input = Console.ReadLine().ToLower();
            if (input == "y")
            {
                int count = 1;
                Console.Clear();
                Console.WriteLine("These are the products in your shopping cart: ");
                foreach (string product in shoppingCart)
                {
                    Console.WriteLine(count + ". " + product);
                    count++;
                }
                removeItem = false;
            }
            else if (input == "n")
            {
                removeItem = false;
            }
            else
            {
                Console.WriteLine("Type 'Y' or 'N'");
            }
        }
    }
    */