// Apparel 7

// Användarinfo -- /data/customerLogin.txt 
// Admininfo -- /data/adminLogin.txt
// Produktinfo -- /data/products.txt
// Kvitton -- /data/receipts.txt

using e_commerce_project;

// Title Display
string[] title = File.ReadAllLines("../../../data/title.txt");
foreach (var line in title)
{
    Console.WriteLine(line);
}
Console.ReadKey();
Console.Clear();

// Init

bool init = true;
do
{
    Console.WriteLine("Welcome to Apparel 7\n1.Login as Customer\n2.Register new Customer\n3.Login as Admin");
    Console.WriteLine();
    Console.Write("Enter choice: ");
    string input = Console.ReadLine();
    switch (input)
    {
        case "1":
            Customer.Login();
            // Menu
            Cart.AddToCart();
            Cart.RemoveFromCart();
            break;
        case "2":
            Customer.Register();
            break;
        case "3":
            Admin.AdminMenu();
            break;
        default:
            Console.WriteLine("Invalid input");
            break;
    }
} while (init);
