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
Console.WriteLine("Press any key to continue...");
Console.ReadKey();
Console.Clear();


Menus.MainMenu();

