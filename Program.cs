// WebShop7
/*
 * 
 *      Menu1:
 *      1. Login --> Enter Username//Password
 *      2. Register --> Enter Username//Email//Password --> WriteToFile!
 *   
 *      ----------------
 *   
 *      User Init Menu
 *      1. Browse Store ----> Browse Products
 *      2. View Cart
 *      3. Order History
 *      4. Logout
 *      
 *      ----------------
 *      
 *      Admin Init Menu
 *      1. Add/Remove Listings --> WriteToFile
 *      2. View/Edit Users
 *      3. View Orders
 *      4. Logout
 *      
 *      ----------------
 *      
 *      Browse Products Menu
 *      -- Displays all products --
 *      * Click product ---> Displays price and option "Add To Cart"
 *      * Back
 *      
 *      */
using e_commerce_project;

Console.WriteLine("1.Login");
Console.WriteLine("2.Register");
string input = Console.ReadLine();
if (int.TryParse(input, out int choice) && choice == 2)
{
    string userInput, passwordInput;
    Register(out userInput, out passwordInput);
    User newUser = new User(userInput, passwordInput);
    newUser.Write();
}

// Register method
static void Register(out string userInput, out string passwordInput)
{
    //while(?)
    Console.Write("Enter username: ");
    userInput = Console.ReadLine();
    Console.Write("Enter password: ");
    passwordInput = Console.ReadLine();
}




