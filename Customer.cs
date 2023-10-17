namespace e_commerce_project;
// Customer Class

// Registrera sig som ny kund.
// Lägg till och ta bort produkter i en varukorg.
// Genomföra köp, spara beställningar och kvitto kopplat till deras konton.
// Se sin egen köphistorik

public class Customer
{
    public string? Username;
    private string? _password;

    public static List<Customer> UserList = new List<Customer>();

    // Gör loop
    // Kolla password & username length
    // Inga whitespaces/null

    public static void Register()
    {

        Console.Clear();
        Customer user = new Customer();
        Console.WriteLine("Register an account.");
        Console.WriteLine("--------------------");

        Console.Write("Username: ");
        user.Username = Console.ReadLine();

        Console.Write("Password: ");
        user._password = Console.ReadLine();
        UserList.Add(user);


        user.SaveCustomerData();

    }
    public static void Login()
    {
        Console.Clear();
        Console.WriteLine("Login to your account.");
        Console.WriteLine("----------------------");
        Console.Write("Username: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();
        bool loggedIn = false;

        while (!loggedIn)
        {
            string[] dataLines = File.ReadAllLines("../../../data/customerLogin.txt");
            foreach (string userDataLine in dataLines)
            {
                string[] userDataParts = userDataLine.Split(':');
                if (userDataParts[0] == username && userDataParts[1] == password)
                {
                    Console.WriteLine("You successfully logged in.");
                    loggedIn = true;
                    File.Create($"../../../carts/{username}.txt").Close();
                    CustomerMenu();
                }
            }

            if (!loggedIn)
            {
                Console.WriteLine("Your username or password is invalid.");
                Console.WriteLine("Try to Login again or Register an account.");
                Console.WriteLine("Answer with L or R");
                string answerLorR = Console.ReadLine().ToLower();
                if (answerLorR == "l")
                {
                    Login();
                    loggedIn = true;
                }
                if (answerLorR == "r")
                {
                    Register();
                    loggedIn = true;
                }
            }
        }
    }
    public void SaveCustomerData()
    {
        List<string> OldUserData = new List<string>();

        OldUserData = File.ReadAllLines("../../../data/customerLogin.txt").ToList();

        List<string> UpdateUserData = new List<string>();
        foreach (Customer user in Customer.UserList)
        {
            UpdateUserData.Add(user.Username + ":" + user._password);
        }
        OldUserData.AddRange(UpdateUserData);

        File.WriteAllLines("../../../data/customerLogin.txt", OldUserData);
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
            Console.WriteLine("3. Order History");
            Console.WriteLine("4. Logout");

            Console.WriteLine("Select 1,2,3 or 4");

            string? customerInput = Console.ReadLine();

            if (customerInput == "1")
            {
                Console.Clear();
                Console.WriteLine("APPAREL 7");
                Cart.AddToCart();
            }
            else if (customerInput == "2")
            {

            }
            else if (customerInput == "3")
            {

            }
            else if (customerInput == "4")
            {
                Menus.MainMenu();
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }
    }

}

