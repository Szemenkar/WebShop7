namespace e_commerce_project;

public class Menus
{
    public static void MainMenu()
    {
        bool remainMain = true;

        do
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("Welcome to Apparel 7");
            Console.WriteLine("--------------------");
            Console.WriteLine("1. Login as Customer\n2. Register new Customer\n3. Login as Admin\n");
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
                    AdminMenu();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid input");
                    break;
            }
        } while (remainMain);
    }

    public static void CustomerMenu()
    {
        bool remainMenu = true;
        while (remainMenu)
        {
            Console.Clear();
            Console.WriteLine("-------------");
            Console.WriteLine("Customer Menu");
            Console.WriteLine("-------------");
            Console.WriteLine("1. Browse Store\n2. View Cart\n3. Remove Item From Cart\n4. Order History\n5. Checkout\n6. Logout\n");
            Console.Write("Enter choice: ");

            string? customerInput = Console.ReadLine();
            switch (customerInput)
            {
                case "1":
                    Console.Clear();
                    Cart.AddToCart();
                    break;
                case "2":
                    Console.Clear();
                    Cart.ViewCart();
                    break;
                case "3":
                    Cart.RemoveFromCart();
                    break;
                case "4":
                    Customer.OrderHistory();
                    break;
                case "5":
                    Console.Clear();
                    Checkout.DisplayOrder();
                    break;
                case "6":
                    Console.Clear();
                    Customer.UserList.Clear();
                    Cart.shoppingCart.Clear();
                    remainMenu = false;
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }
    }

    public static void AdminMenu()
    {
        Console.WriteLine("--------------------------");
        Console.WriteLine("Login to your admin account");
        Console.WriteLine("--------------------------");
        Console.Write("Admin username: ");
        string? username = Console.ReadLine();
        Console.Write("Admin password: ");
        string? password = Console.ReadLine();

        bool adminLogin = true;

        while (adminLogin)
        {
            string[] adminInformation = File.ReadAllLines("../../../data/adminLogin.txt");
            foreach (string item in adminInformation)
            {
                string[] admin = item.Split(':');
                if (admin[0] == username && admin[1] == password)
                {
                    adminLogin = false;
                    Console.Clear();
                    break;
                }
            }

            if (adminLogin)
            {
                Console.WriteLine("Your username or password is invalid. Try again.");
                Console.Write("Admin username: ");
                username = Console.ReadLine();
                Console.Write("Admin password: ");
                password = Console.ReadLine();
                adminLogin = true;
            }
        }

        bool init = true;

        do
        {
            Console.WriteLine("Admin Menu");
            Console.WriteLine("-----------------------");
            Console.WriteLine("1. Add products\n2. Delete products\n3. Edit customer info\n4. View all orders\n5. Back to main menu");
            Console.WriteLine("-----------------------\n");
            Console.Write("Enter choice: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Admin.AddProduct();
                    break;
                case "2":
                    Console.Clear();
                    Admin.DeleteProduct();
                    break;
                case "3":
                    Console.Clear();
                    Admin.EditCustomerInfo();
                    break;
                case "4":
                    Admin.OrderHistory();
                    break;
                case "5":
                    Console.Clear();
                    MainMenu();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid input");
                    break;
            }
        } while (init);
    }
}
