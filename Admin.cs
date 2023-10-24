// Admin class
//    Lägg till och ta bort produkter
//    Visa och redigera alla kunders information
//    Översikt över alla beställningar och transaktioner

namespace e_commerce_project;
public class Admin
{
    public static void OrderHistory()

    {
        string[] allCustomers = File.ReadAllLines("data/customerLogin.txt");

        List<string> Usernames = new();

        foreach (var item in allCustomers)
        {
            string[] Userfile = item.Split(":");
            for (int i = 0; i < Userfile.Length; i += 2)
            {
                Usernames.Add(Userfile[i]);
            }
        }
        while (true)
        {
            Console.Clear();
            Console.WriteLine("----------------");
            Console.WriteLine("List of users:");
            Console.WriteLine("----------------");

            foreach (var user in Usernames)
            {
                Console.WriteLine(user);
            }
            Console.WriteLine();
            Console.WriteLine("Type the name of a user to view their order history\nType 'back' to go back");

            string? input = Console.ReadLine();
            if (input == "back")
            {
                Console.Clear();
                break;
            }
            else if (File.Exists($"userdata/{input}.txt"))
            {
                Console.Clear();
                string[] history = File.ReadAllLines($"userdata/{input}.txt");
                foreach (var item in history)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Press any key to return");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No order history for user " + input);
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
    public static void AddProduct()
    {
        Console.Clear();
        bool newlisting = true;
        Product.Get();
        while (newlisting)
        {
            Console.WriteLine("Type the name of the product you wish to add.");

            string? productTitle = Console.ReadLine();

            Console.WriteLine("Type the price ($) of the product you wish to add.");

            string? productPrice = Console.ReadLine();

            if (double.TryParse(productPrice, out double price))
            {
                StreamWriter write = File.AppendText("data/products.txt");
                write.WriteLine($"{productTitle}:${productPrice}");
                write.Close();
                Console.Clear();
                Console.WriteLine("****************************");
                Console.WriteLine("Listing successfully created");
                Console.WriteLine("****************************");
                Console.WriteLine($"New product: {productTitle} (${productPrice})");
                Console.WriteLine();

                bool newProduct = true;

                while (newProduct)
                {
                    Console.Write("Would you like to add another listing? Y/N: ");
                    string? prompt = Console.ReadLine().ToLower();
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
        Console.Clear();
    }

    public static void DeleteProduct()
    {
        Console.Clear();
        while (true)
        {
            Product.ShowAll();
            Console.WriteLine("What products would you like to delete?\nType 'back' to go back");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int selectedIndex) && selectedIndex >= 1 && selectedIndex <= Product.list.Count)
            {
                string deletedProduct = Product.list[selectedIndex - 1];
                Product.Delete(deletedProduct);
                Console.Clear();
                Console.WriteLine(deletedProduct + " has been deleted");
                Console.WriteLine("Press any key to return to the admin menu");
                Console.ReadLine();
            }
            else if (input == "back")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid index. Press Enter to try again.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        Console.Clear();
    }


    public static void EditCustomerInfo()
    {
        {
            Console.WriteLine("Edit Customer Information");
            string[] info = File.ReadAllLines("data/customerLogin.txt");

            // visar customer list samt ger user val att kunna välja 1,2,3 
            for (int i = 0; i < info.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {info[i]}");
            }

            // välj valfri kund
            Console.Write("Select a customer to edit (enter the number): ");
            if (int.TryParse(Console.ReadLine(), out int customerIndex) && customerIndex >= 1 && customerIndex <= info.Length)
            {
                // vill du ändra namn eller lösen
                Console.Write("What would you like to edit? (1. Name, 2. Password): ");
                if (int.TryParse(Console.ReadLine(), out int editChoice) && (editChoice == 1 || editChoice == 2))
                {
                    Console.Write("Enter the updated information: ");
                    string? updatedInfo = Console.ReadLine();

                    // efter ändringen ska det sparas
                    string[] customerData = info[customerIndex - 1].Split(':');
                    if (editChoice == 1)
                    {
                        // Updatera namn
                        customerData[0] = updatedInfo;
                        info[customerIndex - 1] = updatedInfo + ":" + customerData[1];
                    }
                    else if (editChoice == 2)
                    {
                        // Updatera lösen
                        customerData[1] = updatedInfo;
                        info[customerIndex - 1] = customerData[0] + ":" + updatedInfo;
                    }

                    // uppdaterar ändringen till filen
                    File.WriteAllLines("data/customerLogin.txt", info);

                    Console.WriteLine("Customer information updated successfully.");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                }
            }
            else
            {
                Console.WriteLine("No such customer");
            }
        }
        Console.Clear();
    }
}
