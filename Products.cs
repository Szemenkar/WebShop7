namespace e_commerce_project;
public class Products
{
    public List<Products> productlist = new List<Products>();

    // Constructor
    public Products(List<Products> productlist)
    {
        this.productlist = productlist;
    }

    public static void fetchProducts()
    {
        string[] products = File.ReadAllLines("../../../data/products.txt");
        int productIndex = 1;
        foreach (var product in products)
        {
            Console.WriteLine(productIndex+". "+product);
            productIndex++;
        }

    }
}