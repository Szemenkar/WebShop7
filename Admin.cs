// Admin class
//    Lägg till och ta bort produkter
//    Visa och redigera alla kunders information
//    Översikt över alla beställningar och transaktioner

namespace e_commerce_project;
public class Admin
{
    public static void AdminMenu()
    {
        Console.Write("Admin username: ");
        string? username = Console.ReadLine();
        Console.Write("Admin password: ");
        string? password = Console.ReadLine();

        bool adminLogin = true;

        while (adminLogin)
        {
            string[] adminInformation = File.ReadAllLines("../../../data/adminLogin.txt");
            foreach (string item in adminInformation)
            {
                string[] admin = item.Split(':');
                if (admin[0] == username && admin[1] == password)
                {
                    Console.WriteLine("You successfully logged in.");
                    adminLogin = false;
                    break;
                }
            }

            if (adminLogin)
            {
                Console.WriteLine("Your username or password is invalid. Try again.");
                Console.Write("Admin username: ");
                username = Console.ReadLine();
                Console.Write("Admin password: ");
                password = Console.ReadLine();
                adminLogin = true;
            }
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Admin Menu:");
            Console.WriteLine("-----------------------");
            Console.WriteLine("1. Add products");
            Console.WriteLine("2. Delete products");
            Console.WriteLine("3. Edit customer info");
            Console.WriteLine("4. View all orders");
            Console.WriteLine("5. Back");
            Console.WriteLine();
            Console.WriteLine("-----------------------");

            Console.Write("Enter your choice: ");
            string? choice = Console.ReadLine();
            Console.Clear();

            if (choice == "1")
            {
                Console.Clear();

                Admin.AddProduct();

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
                    string deletedProduct = Product.list[selectedIndex - 1];
                    Product.Delete(deletedProduct);

                    Console.WriteLine(deletedProduct + " has been deleted");

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
                {
                    Console.WriteLine("Edit Customer Information");
                    string[] info = File.ReadAllLines("../../../data/customerLogin.txt");

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
                            }
                            else if (editChoice == 2)
                            {
                                // Updatera lösen
                                customerData[1] = updatedInfo;
                            }

                            if (editChoice == 1)
                            {

                                info[customerIndex - 1] = updatedInfo + ":" + customerData[1];
                            }
                            else if (editChoice == 2)
                            {
                                info[customerIndex - 1] = customerData[0] + ":" + updatedInfo;
                            }

                            // uppdaterar ändringen till filen
                            File.WriteAllLines("../../../data/customerLogin.txt", info);

                            Console.WriteLine("Customer information updated");
                            Console.WriteLine("Press any key to continue...");
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

            }
            else if (choice == "4")
            {
                Admin.OrderHistory();
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

    public static void OrderHistory()

    {
        string[] allCustomers = File.ReadAllLines("../../../data/customerLogin.txt");

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
            else if (File.Exists($"../../../userdata/{input}.txt"))
            {
                Console.Clear();
                string[] history = File.ReadAllLines($"../../../userdata/{input}.txt");
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

    }

}
