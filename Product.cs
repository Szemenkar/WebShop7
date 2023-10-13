namespace e_commerce_project;
public class Product
{
    public static List<string> list = new List<string>();
    public static string ProductPath = "../../../data/products.txt";

    // Uppdatera (Get) och Visa Alla Produkter
    public static void ShowAll()
    {
        Get();

        int indexer = 1;

        foreach (var product in list)
        {
            Console.WriteLine($"{indexer}. {product}");
            indexer++;
        }
    }

    // metoder som ändrar produkter
    // exempelvis:

    // Product.Get();
    // Product.Add(productname);
    // Product.Delete(productname);

    public static void Get()
    {
        list = File.ReadAllLines(ProductPath).ToList();
    }

    public static void Rewrite()
    {
        File.WriteAllLines(ProductPath, list);
    }

    public static void Make(string product)
    {
        list.Add(product);
        Rewrite();
    }

    public static void Delete(string product)
    {
        list.Remove(product);
        Rewrite();
    }
}