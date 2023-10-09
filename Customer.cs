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
        private static int _usercount = 0;

        // Constructor
        public Customer(string username, string password)
        {
            Username = username;
            _password = password;
            _usercount++;
        }
        public static int UserCount => _usercount;

    }

