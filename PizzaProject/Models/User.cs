using Newtonsoft.Json;
using PizzaProject.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PizzaProject.Models
{
    class User
    {
        private bool _isAdmin;
        public int Id { get; set; }
        public bool Admin
        {
            get => _isAdmin;
            set
            {
                {
                    _isAdmin = value;
                }
            }
        }
        public string Name
        {
            get;set;
        }
        public string Surname
        {
            get;set;
        }
        public string Username
        {
            get;set;
        }
        public string Password
        {
            get;set;
        } 
        public static bool CheckUpperLetter(string word)
        {

            bool result = false;
            for (int i = 0; i < word.Length; i++)
            {
                if (char.IsUpper(word[i]))
                {
                    result = true;
                }

            }
            return result;
        }
        public static bool CheckLowLetter(string word)
        {
            bool result = false;
            for (int i = 0; i < word.Length; i++)
            {
                if (char.IsLower(word[i]))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public static bool CheckDigit(string word)
        {
            bool result = false;
            for (int i = 0; i < word.Length; i++)

            {
                if (char.IsDigit(word[i]))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        public static bool CheckPassword(string value)
        {
            bool check = false;
            if (CheckDigit(value) && CheckLowLetter(value) && CheckUpperLetter(value))
            {
                check = true;
            }
            return check;

        }
    public static void IsAdmin(int id)
    {
        List<User> users;
        using (StreamReader sr = new StreamReader("c:\\users\\hp\\desktop\\pizzaproject\\pizzaproject\\files\\users.json"))
        {
            users = JsonConvert.DeserializeObject<List<User>>(sr.ReadToEnd());
        }
        User user = users.Find(user => user.Id == id);
        if (user.Admin == false)
        {
            user.Admin = true;
        }
    }
}
}
