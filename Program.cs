// Apparel 7

// Användarinfo -- /data/customerLogin.txt 
// Admininfo -- /data/adminLogin.txt
// Produktinfo -- /data/products.txt
// Kvitton -- /data/receipts.txt

string[] title = File.ReadAllLines("../../../data/title.txt");
foreach (var line in title)
{
    Console.WriteLine(line);
}
