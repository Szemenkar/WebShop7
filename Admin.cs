// Admin class
//    Lägg till och ta bort produkter
//    Visa och redigera alla kunders information
//    Översikt över alla beställningar och transaktioner

namespace e_commerce_project;
public class Admin
{
    public string name;
    public Admin(string Name) => Name = name;

    public static void AddProduct()
    {
        bool newlisting = true;

        while (newlisting)
        {
            Console.WriteLine("Type the name of the product you wish to add.");

            string productTitle = Console.ReadLine();

            Console.WriteLine("Type the price ($) of the product you wish to add.");

            string productPrice = Console.ReadLine();

            if (double.TryParse(productPrice, out double price))
            {
                // initierar objekt från StreamWriter (inbyggd klass m. string path som argument)
                StreamWriter productEditor = File.AppendText("../../../data/products.txt");

                // callar metoden WriteLine (skriver ny line till instansens path)
                productEditor.WriteLine($"{productTitle}:${productPrice}");

                // callar metoden Close (annars sparas inte ändringarna)
                productEditor.Close();

                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("****************************");
                Console.WriteLine("Listing successfully created.");
                Console.WriteLine("****************************");
                Console.WriteLine();

                bool newProduct = true;

                while (newProduct)
                {
                    Console.WriteLine("Would you like to add another listing? Y/N");
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

