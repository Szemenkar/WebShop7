namespace e_commerce_project;

public class Menus
{
    public static void MainMenu()
    {
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
                    Console.Clear();
                    Customer.Login();
                    // Menu
                    Cart.AddToCart();
                    Cart.RemoveFromCart();
                    break;
                case "2":
                    Console.Clear();
                    Customer.Register();
                    break;
                case "3":
                    Console.Clear();
                    Admin.AdminMenu();

                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid input");

                    break;
            }
        } while (init);
    }
}
