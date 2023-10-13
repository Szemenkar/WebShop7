// Admin class
//    Lägg till och ta bort produkter
//    Visa och redigera alla kunders information
//    Översikt över alla beställningar och transaktioner

namespace e_commerce_project;
public class Admin
{
    public string name;
    public Admin(string Name) => Name = name;

    public static void AdminMenu()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("Welcome to the Admin Menu:");
            Console.WriteLine("*****************");
            Console.WriteLine("1. Add products");
            Console.WriteLine("2. Delete products");
            Console.WriteLine("3. Edit customer info");
            Console.WriteLine("4. View all orders");
            Console.WriteLine("5. Back");
            Console.WriteLine("*****************");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Clear();

                Admin.AddProduct();

                Thread.Sleep(1000);

                Console.Clear();

                Console.WriteLine("Press Enter to return to admin menu");

                Console.ReadLine();

                Console.Clear();
            }
            else if (choice == "2")
            {
                Console.Clear();

                Product.ShowAll();

                Console.WriteLine("What products would you like to delete?");

                if (int.TryParse(Console.ReadLine(), out int selectedIndex) && selectedIndex >= 1 && selectedIndex <= Product.list.Count)
                {
                    string deletedProduct = Product.list[selectedIndex -1];
                    Product.Delete(deletedProduct);
                    
                    Console.WriteLine(deletedProduct + " Is now removed");

                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("Press Enter to return to the admin menu");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Invalid index. Press Enter to try again.");
                    Console.ReadLine();
                }

                Console.Clear();
            }
            else if (choice == "3")
            {
                Console.WriteLine("Edit customer information.");
                // Add code for Option 3 here
                Console.WriteLine("1.");
                Console.WriteLine("2.");
                Console.WriteLine("3.");
                Console.WriteLine("4.");

                string val = Console.ReadLine();
            }
            else if (choice == "4")
            {
                Console.WriteLine("Orders & Transactions:");
                // Add code for Option 4 here
                Console.WriteLine("1.");
                Console.WriteLine("2.");
                Console.WriteLine("3.");
                Console.WriteLine("4.");
            }
            else if (choice == "5")
            {
                Console.Clear();
                break;
            }
            else
            {
                Console.WriteLine("Incorrect choice. Press Enter to try again.");
                Console.ReadLine();
            }
        }
    }
    public static void AddProduct()
    {
        bool newlisting = true;
        Product.Get();
        while (newlisting)
        {
            Console.WriteLine("Type the name of the product you wish to add.");

            string productTitle = Console.ReadLine();

            Console.WriteLine("Type the price ($) of the product you wish to add.");

            string productPrice = Console.ReadLine();

            if (double.TryParse(productPrice, out double price))
            {
                StreamWriter write = File.AppendText("../../../data/products.txt");
                write.WriteLine($"{productTitle}:${productPrice}");
                write.Close();

                Console.Clear();
                Console.WriteLine("****************************");
                Console.WriteLine("Listing successfully created.");
                Console.WriteLine("****************************");
                Console.WriteLine();

                bool newProduct = true;

                while (newProduct)
                {
                    Console.Write("Would you like to add another listing? Y/N: ");
                    string prompt = Console.ReadLine().ToLower();
                    if (prompt == "y")
                    {
                        Console.Clear();
                        newProduct = false;
                    }
                    else if (prompt == "n")
                    {
                        newlisting = false;
                        newProduct = false;
                    }
                    else
                    {
                        Console.WriteLine("Type \"n\" or \"y\"");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid price, please use decimal number.");
            }
        }

    }

}
