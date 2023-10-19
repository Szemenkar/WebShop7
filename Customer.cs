﻿namespace e_commerce_project;
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
        Console.WriteLine("Register an account");
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
        Console.WriteLine("Login to your account");
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
        Console.WriteLine("-------------");
        Console.WriteLine("Order History");
        Console.WriteLine("-------------");
        Console.Clear();
        string[] history = File.ReadAllLines($"../../../userdata/{UserList[0].Username}.txt");
        foreach (var item in history)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
        Console.WriteLine("----------------------------------------");
        Console.WriteLine();
        Console.WriteLine("Press any key to go back");
        Console.ReadKey();
    }
}