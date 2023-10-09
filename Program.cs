using e_commerce_project;
// Apparel 7
string[] title = File.ReadAllLines("../../../title.txt");
foreach (var line in title)
{
    Console.WriteLine(line);
}

// "../../../"

// Användarinfo -- customerLogin.txt 
// Admininfo -- adminLogin.txt
// Produktinfo -- products.txt
// Kvitton -- receipts.txt

// Add to Cart
// Complete Purchase --> makeOrder (save receipt)