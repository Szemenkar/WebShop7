// Admin class
//    Lägg till och ta bort produkter
//    Visa och redigera alla kunders information
//    Översikt över alla beställningar och transaktioner

namespace e_commerce_project;
public class Admin
{
    public static void Main(string[] args)
    {
        List<string> kläder = new List<string> { "hoodie", "byxor", "bag" };

        while (true)
        {
            Console.Clear();

            Console.WriteLine("Welcome to the menu Admin:");
            Console.WriteLine("1. Add products");
            Console.WriteLine("2. Delete products");
            Console.WriteLine("3. Redigera kundinformation");
            Console.WriteLine("4. Översikt över alla Beställningar & Transaktioner");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Clear();

                Console.WriteLine("What product would you like to add?");
                string add = Console.ReadLine();
                kläder.Add(add);
                Console.WriteLine(add + " is now added to your products!");


                Thread.Sleep(800);
                Console.WriteLine("Press Enter to return to the main menu");
                Console.ReadLine();

                Console.Clear();
            }
            else if (choice == "2")
            {
                Console.Clear();

                Console.WriteLine("What products would you like to delete?");

                for (int i = 0; i < kläder.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {kläder[i]}");
                }

                if (int.TryParse(Console.ReadLine(), out int selectedIndex) && selectedIndex >= 1 && selectedIndex <= kläder.Count)
                {
                    string deletedProduct = kläder[selectedIndex - 1];
                    kläder.RemoveAt(selectedIndex - 1);
                    Console.WriteLine(deletedProduct + " Is now removed");

                    Thread.Sleep(1000);
                    Console.WriteLine("Press Enter to return to the main menu");
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
            else
            {
                Console.WriteLine("Incorrect choice. Press Enter to try again.");
                Console.ReadLine();
            }
        }
    }
}

