using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce_project;
    public class User
    {
        public string Username;
        public string _password;

        private static int _usercount = 0;
        private readonly bool _isadmin = false;

        private readonly static List<User> users = new List<User>();

        // Constructor
        public User(string username, string password)
        {
            Username = username;
            _password = password;
            _usercount++;
        }
        public static int UserCount => _usercount;

        // Write userfile
        public void Write()
        {
            users.Add(this);
            string userDetails = Username + "//" + _password;
            File.WriteAllText("../../../usercredentials.txt", userDetails);
            Console.WriteLine("User Saved and Logged in");
        }
    }