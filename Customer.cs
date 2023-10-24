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

    public static void Register()
    {
        Customer user = new Customer();
        string[] usernames = File.ReadAllLines("data/customerLogin.txt");
        List<string> formattedUswername = new();
        Console.Clear();
        Console.WriteLine("-------------------");
        Console.WriteLine("Register an account");
        Console.WriteLine("-------------------");
        bool exists = false;
        do
        {
            exists = false;
            foreach (var item in usernames)
            {
                string[] items = item.Split(":");
                formattedUswername.Add(items[0]);
            }

            Console.Write("Username: ");
            user.Username = Console.ReadLine();


            for (int i = 0; i < formattedUswername.Count - 1; i++)
            {
                if (formattedUswername[i].Equals(user.Username))
                {
                    Console.Clear();
                    Console.WriteLine("Username already exists, try another name");
                    exists = true;
                }
            }

        } while (exists);

        Console.Clear();
        bool passLength = true;

        while (passLength)
        {
            Console.Write("Password: ");
            user._password = Console.ReadLine() ?? string.Empty;
            if (user._password.Length < 6 || user._password.Length > 20)
            {
                Console.Clear();
                Console.WriteLine("Password length must be between 6 and 20 characters long");
            }
            else if (user._password.Contains(" "))
            {
                Console.Clear();
                Console.WriteLine("No whitespaces in the password is allowed");
            }
            else
            {
                passLength = false;
            }
        }

        UserList.Add(user);
        File.Create($"userdata/{user.Username}.txt").Close();
        user.SaveCustomerData();
        Console.Clear();
        Console.WriteLine($"Customer '{user.Username}' was created succesfully!\nPress any key to continue");
        Console.ReadKey();
        Console.Clear();
    }

    public static void Login()
    {
        Console.Clear();
        Console.WriteLine("----------------------");
        Console.WriteLine("Login to your account");
        Console.WriteLine("----------------------");
        Console.Write("Username: ");
        string? username = Console.ReadLine();
        Console.Write("Password: ");
        string? password = Console.ReadLine();
        bool loggedIn = false;

        while (!loggedIn)
        {
            string[] dataLines = File.ReadAllLines("data/customerLogin.txt");
            foreach (string userDataLine in dataLines)
            {
                string[] userDataParts = userDataLine.Split(':');
                if (userDataParts[0] == username && userDataParts[1] == password)
                {
                    Customer user = new Customer();
                    user.Username = userDataParts[0];
                    UserList.Add(user);
                    loggedIn = true;
                    Menu.Customers();
                }
            }

            if (!loggedIn)
            {
                Console.WriteLine("Your username or password is invalid.");
                Console.WriteLine("Try to login again or register a new account.");
                Console.Write("Type L for Login or R for Register: ");
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

        OldUserData = File.ReadAllLines("data/customerLogin.txt").ToList();

        List<string> UpdateUserData = new List<string>();
        foreach (Customer user in Customer.UserList)
        {
            UpdateUserData.Add(user.Username + ":" + user._password);
        }
        OldUserData.AddRange(UpdateUserData);

        File.WriteAllLines("data/customerLogin.txt", OldUserData);
    }

    public static void OrderHistory()
    {
        Console.Clear();

        Console.WriteLine("Order History:");
        Console.WriteLine();
        string[] receipts = File.ReadAllLines($"userdata/{UserList[0].Username}.txt");

        if (receipts.Length == 0 || !File.Exists($"userdata/{UserList[0].Username}.txt"))
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("No order history found!");
            Console.WriteLine("----------------------");
        }
        else
        {

            // Skapar lista över orders (hämtar första raden i varje order)
            List<string> orderlist = new List<string>();

            for (int i = 0; i < receipts.Length; i++)
            {
                if (receipts[i].StartsWith("20"))
                {
                    orderlist.Add(receipts[i]);
                }
            }

            int indexer = 1;

            // Skriver ut listan och indexerar
            foreach (var item in orderlist)
            {
                Console.WriteLine($"Order #{indexer} -- {item}");
                indexer++;
            }

            Console.WriteLine();
            Console.WriteLine("Enter order number to view order");
            Console.WriteLine("Type 'back' to go back");

            string? input = Console.ReadLine();

            Console.Clear();

            if (int.TryParse(input, out int x) && x >= 1 && x <= orderlist.Count)
            {
                string orderChoice = orderlist[x - 1];

                // Hittar en string i en array och ger en index-int
                int receiptStart = Array.IndexOf(receipts, orderChoice);
                int receiptEnd = receiptStart;

                // Adderar 1 (line) till receiptEnd tills den når raden "Total sum"
                while (receiptEnd < receipts.Length && !receipts[receiptEnd].Contains("Total sum:"))
                {
                    receiptEnd++;
                }

                // Skriver ut kvittot
                for (int i = receiptStart; i < receiptEnd + 1; i++)
                {
                    Console.WriteLine(receipts[i]);
                }
            }
            else if (input == "back")
            {
                Menu.Customers();
            }
            else
            {
                Console.WriteLine("Order number not found.");
            }
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Press any key to go back");
        Console.ReadKey();
    }
}