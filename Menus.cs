namespace e_commerce_project;

public class Menus
{
    public static void MainMenu()
    {
        bool init = true;

        do
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("Welcome to Apparel 7");
            Console.WriteLine("--------------------");
            Console.WriteLine("1.Login as Customer\n2.Register new Customer\n3.Login as Admin");

            Console.WriteLine();

            Console.Write("Enter choice: ");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Clear();
                    Customer.Login();
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

    public static void CustomerMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("-------------");
            Console.WriteLine("Customer Menu");
            Console.WriteLine("-------------");
            Console.WriteLine("1. Browse Store");
            Console.WriteLine("2. View Cart");
            Console.WriteLine("3. Order History");
            Console.WriteLine("4. Checkout");
            Console.WriteLine("5. Logout");

            string? customerInput = Console.ReadLine();

            if (customerInput == "1")
            {
                Console.Clear();
                Cart.AddToCart();
            }
            else if (customerInput == "2")
            {
                Console.Clear();
                Cart.ViewCart();
                Cart.RemoveFromCart();
            }
            else if (customerInput == "3")
            {
                Customer.OrderHistory();
                Console.ReadKey();
            }
            else if (customerInput == "4")
            {
                Console.Clear();
                Checkout.DisplayOrder();
            }
            else if (customerInput == "5")
            {
                Console.Clear();
                Customer.UserList.Clear();
                break;
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }
    }
}
