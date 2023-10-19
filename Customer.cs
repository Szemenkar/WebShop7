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
        Customer user = new Customer();
        Console.Clear();
        Console.WriteLine("-------------------");
        Console.WriteLine("Register an account.");
        Console.WriteLine("-------------------");

        Console.Write("Username: ");
        user.Username = Console.ReadLine();

        Console.Write("Password: ");
        user._password = Console.ReadLine();
        UserList.Add(user);

        File.Create($"../../../userdata/{user.Username}.txt").Close();

        user.SaveCustomerData();

        Console.Clear();

    }
    public static void Login()
    {
        Console.Clear();
        Console.WriteLine("----------------------");
        Console.WriteLine("Login to your account.");
        Console.WriteLine("----------------------");
        Console.Write("Username: ");
        string? username = Console.ReadLine();
        Console.Write("Password: ");
        string? password = Console.ReadLine();
        bool loggedIn = false;

        while (!loggedIn)
        {
            string[] dataLines = File.ReadAllLines("../../../data/customerLogin.txt");
            foreach (string userDataLine in dataLines)
            {
                string[] userDataParts = userDataLine.Split(':');
                if (userDataParts[0] == username && userDataParts[1] == password)
                {
                    Customer user = new Customer();
                    Console.WriteLine("You successfully logged in.");
                    user.Username = userDataParts[0];
                    UserList.Add(user);
                    loggedIn = true;
                    Menus.CustomerMenu();
                }
            }

            if (!loggedIn)
            {
                Console.WriteLine("Your username or password is invalid.");
                Console.WriteLine("Try to Login again or Register an account.");
                Console.WriteLine("Answer with L or R");
                string? answerLorR = Console.ReadLine().ToLower();
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

    public static void OrderHistory()
    {
        Console.Clear();
        Console.WriteLine("Orders");
        Console.WriteLine();
        string[] receipts = File.ReadAllLines($"../../../userdata/{UserList[0].Username}.txt");

        int indexer = 1;

        // Skapar lista över orders (hämtar första raden i varje order)
        List<string> orderlist = new List<string>();

        for (int i = 0; i < receipts.Length; i += 12)
        {
            orderlist.Add(receipts[i]);
        }

        // Skriver ut listan och indexerar
        foreach (var item in orderlist)
        {
            Console.WriteLine($"Order #{indexer} -- {item}");
            indexer++;
        }

        Console.WriteLine();
        Console.WriteLine("Enter order number to view order");

        string? input = Console.ReadLine();

        Console.Clear();

        for (int i = 0; i < orderlist.Count; i++)
        {
            if (int.TryParse(input, out int x) && orderlist[i] == orderlist[x])
            {
                for (int y = x * 12 + 1; y < x * 12 + 12; y++)
                {
                    Console.WriteLine(receipts[y]);
                }
            }
            else
            {
                Console.WriteLine("Order number not found.");
            }
        
        }


        //foreach (var orderdetail in receipts)

        //{
        //    Console.WriteLine(orderdetail);
        //}
        Console.WriteLine();
        Console.WriteLine("----------------------------------------");
        Console.WriteLine();
        Console.WriteLine("Press any key to go back");
        Console.ReadKey();
    }
}

