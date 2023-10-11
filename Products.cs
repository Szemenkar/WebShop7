namespace e_commerce_project;
public class Products
{
    public static void fetchProducts()
    {
        string[] products = File.ReadAllLines("../../../data/products.txt");
        foreach (var product in products)
        {
            Console.WriteLine(product);
        }
    }
}