// Apparel 7
// "../../../"

// Användarinfo -- /data/customerLogin.txt 
// Admininfo -- /data/adminLogin.txt
// Produktinfo -- /data/products.txt
// Kvitton -- /data/receipts.txt

// Add to Cart
// Complete Purchase --> makeOrder (save receipt)

string[] title = File.ReadAllLines("../../../data/title.txt");
foreach (var line in title)
{
    Console.WriteLine(line);
}
