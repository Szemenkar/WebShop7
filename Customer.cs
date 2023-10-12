namespace e_commerce_project;
// Customer Class

// Registrera sig som ny kund.
// Lägg till och ta bort produkter i en varukorg.
// Genomföra köp, spara beställningar och kvitto kopplat till deras konton.
// Se sin egen köphistorik

public class Customer
    {
    public string Username;
    public string _password;
    public string Email;


    public static List<Customer> UserList = new List<Customer>();
    public static void Register()
    {
        Console.Clear();
        Customer user = new Customer();
        Console.WriteLine("Register an account.");
        Console.WriteLine("--------------------");
        Console.Write("Email: ");
        user.Email = Console.ReadLine();

        Console.Write("Username: ");
        user.Username = Console.ReadLine();

        Console.Write("Password: ");
        user._password = Console.ReadLine();
        UserList.Add(user);

        SaveCustomerData();
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
            string[] dataLines = File.ReadAllLines("../../../customerLogin.txt");

            foreach (string userDataLine in dataLines)
            {
                string[] userDataParts = userDataLine.Split(',');

                if (userDataParts[1] == username && userDataParts[2] == password)
                {
                    Console.WriteLine("Your successfully logged in.");
                    loggedIn = true;
                    break;
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
                }
                if (answerLorR == "r")
                {
                    Register();
                    loggedIn = true;
                }
            }
        }
    }
    public static void SaveCustomerData()
    {
        List<string> OldUserData = new List<string>();

        OldUserData = File.ReadAllLines("../../../customerLogin.txt").ToList();

        List<string> UpdateUserData = new List<string>();
        foreach (Customer user in Customer.UserList)
        {
            UpdateUserData.Add(user.Email + "," + user.Username + "," + user._password);
        }
        OldUserData.AddRange(UpdateUserData);

        File.WriteAllLines("../../../customerLogin.txt", OldUserData);
    }

}

