namespace e_commerce_project;

public class Menus
{
    public static void MainMenu()
    {
        bool init = true;

        do
        {
            Console.WriteLine("Welcome to Apparel 7\n\n1.Login as Customer\n2.Register new Customer\n3.Login as Admin");

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
            Console.WriteLine("Customer Menu");
            Console.WriteLine("-------------");
            Console.WriteLine("1. Browse Store");
            Console.WriteLine("2. View Cart");
            Console.WriteLine("3. Remove Item From Cart");
            Console.WriteLine("4. Order History");
            Console.WriteLine("5. Checkout");
            Console.WriteLine("6. Logout");

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
            }
            else if (customerInput == "3")
            {
                Cart.RemoveFromCart();
            }
            else if (customerInput == "4")
            {
                Customer.OrderHistory();
            }
            else if (customerInput == "5")
            {
                Console.Clear();
                Checkout.DisplayOrder();
            }
            else if (customerInput == "6")
            {
                Console.Clear();
                Customer.UserList.Clear();
                Cart.shoppingCart.Clear();
                break;
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }
    }
}
