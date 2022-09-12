using Newtonsoft.Json;
using PizzaProject.Models;
using PizzaProject.Utilities;
using System;
using System.Collections.Generic;
using System.IO;

namespace PizzaProject
{
    class Program
    {
        static void Main(string[] args)
        {

            List<User> users = new List<User>();
        Menu:
            Console.WriteLine("1-login");
            Console.WriteLine("2-qeydiyyat");
            try
            {
                Console.WriteLine("please input:");
                int key = Convert.ToInt32(Console.ReadLine());
                switch (key)
                {
                    case 1:
                    LoginMenu:
                        using (StreamReader sr = new StreamReader("c:\\users\\hp\\desktop\\pizzaproject\\pizzaproject\\files\\users.json"))
                        {
                            users = JsonConvert.DeserializeObject<List<User>>(sr.ReadToEnd());
                        }
                        Console.WriteLine("Username daxil edin");
                        string LoginUser = Console.ReadLine();
                        Console.WriteLine("Password daxil edin");
                        string LoginPassword = Console.ReadLine();
                        User user = users.Find(u => u.Username == LoginUser && u.Password == LoginPassword);
                        if (user == null)
                        {
                            Console.WriteLine("Username ve ya Parol yanlisdir");
                            goto LoginMenu;
                        }
                        else if (user != null && user.Admin == false)
                            UserMethods.UserMenu();
                        else if (user != null && user.Admin == true)
                            UserMethods.AdminMenu();
                        break;
                    case 2:
                    Register:
                        try
                        {
                            Name:
                            Console.WriteLine("Name daxil edin ");
                            string name = Console.ReadLine();
                            if ( name.Length<3)
                            {
                                Console.WriteLine("name in uzunluqu 3 den kicik ola bilmez");
                                goto Name;
                            }
                            Surname:
                            Console.WriteLine("surname daxil edin");
                            string surname = Console.ReadLine();
                            if (surname.Length<6)
                            {
                                Console.WriteLine("surname uzunluqu 6 dan kicik ola bilmez");
                                goto Surname;
                            }
                        Username:
                            Console.WriteLine("username daxil et");
                            string username = Console.ReadLine();
                        password:
                            Console.WriteLine("parolu daxil et");
                            string password = Console.ReadLine();

                            if (User.CheckPassword(password) && username != null)
                            {
                                using (StreamReader sr = new StreamReader("c:\\users\\hp\\desktop\\pizzaproject\\pizzaproject\\files\\users.json"))
                                {
                                    users = JsonConvert.DeserializeObject<List<User>>(sr.ReadToEnd());
                                }
                                User Checkuser = users.Find(u => u.Username == username && u.Password == password);
                                if (Checkuser==null)
                                {

                                    UserMethods.UserAdd(name, surname, username, password);
                                    Console.WriteLine("Xos geldiniz  " + name + " " + surname);
                                    goto Menu;
                                }

                                else
                                {
                                    Console.WriteLine("bele bir username movcuddur,zehmet olmasa basqa bir username secin ");
                                    goto Username;
                                }

                            }
                            else if (username == null)
                            {
                                Console.WriteLine("username 3-16 araliginda olmaldir,zehmet olmasa yeniden yazin ");
                                goto Username;
                            }
                            else if (!User.CheckPassword(password))
                            {
                                Console.WriteLine("Parol 6-16 uzunluqda olmalı, en azı 1 böyük, 1 kiçik herflerden ve en azı 1 reqem qeyd olunmalıdır.");
                                goto password;
                            }
                            break;
                        }
                        catch (NullException)
                        {
                            Console.WriteLine("zehmet olmasa duzgun yazin");
                            goto Register;
                        }

                    default:
                        if (key != 1 && key != 2)
                        {
                            Console.WriteLine("yanlis reqem daxil edirsiniz ,zehmet olmasa duzgun yazin");
                            goto Menu;
                        }
                        break;
                }
            }
            catch (SystemException)
            {
                Console.WriteLine("zehmet olmasa menyunun telimatlarina duzgun emel edin");
                goto Menu;
            }
        }
    }
}