using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PizzaProject.Models
{
    class UserMethods
    {
        public static double price = 0;

        public static void UserAdd(string name, string surname, string username, string password)
        {
            List<User> users;
            using (StreamReader sr = new StreamReader("c:\\users\\hp\\desktop\\pizzaproject\\pizzaproject\\files\\users.json"))
            {
                users = JsonConvert.DeserializeObject<List<User>>(sr.ReadToEnd());
            }
            User user = users.FindLast(user => user.Id == user.Id);
            int id = user.Id + 1;
            users.Add(new User
            {
                Name = name,
                Surname = surname,
                Username = username,
                Password = password,
                Id = id,
                Admin = false,
            });

            using (StreamWriter sw = new StreamWriter("c:\\users\\hp\\desktop\\pizzaproject\\pizzaproject\\files\\users.json"))
            {
                sw.Write(JsonConvert.SerializeObject(users));
            }

        }
        public static List<User> UserReader()
        {
            List<User> users;
            using (StreamReader sr = new StreamReader("c:\\users\\hp\\desktop\\pizzaproject\\pizzaproject\\files\\users.json"))
            {
                users = JsonConvert.DeserializeObject<List<User>>(sr.ReadToEnd());
            }
            return users;
        }
        public static void PrintUser()
        {
            List<User> users;
            using (StreamReader sr = new StreamReader("c:\\users\\hp\\desktop\\pizzaproject\\pizzaproject\\files\\users.json"))
            {
                users = JsonConvert.DeserializeObject<List<User>>(sr.ReadToEnd());
            }
            foreach (User item in users)
            {
                Console.WriteLine("\nName:" + item.Name + "\nSurname:" + item.Surname + "\nUsername:" + item.Username + "\nId:" + item.Id + "\nAdmin: " + item.Admin);
            }
        }

        public static void UserMenu()
        {
            {
            Menu:
                Console.WriteLine("\n1.Pizzalara bax");
                Console.WriteLine("\n2.Sifaris ver");
                Console.WriteLine("please input");
                int input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {

                    case 1:
                    Pizza:
                        PizzaMethods.PrintPizza();
                   
                        List<Pizza> pizzas;
                        using (StreamReader sr = new StreamReader("C:\\Users\\HP\\Desktop\\PizzaProject\\PizzaProject\\Files\\Products.json"))
                        {
                            pizzas = JsonConvert.DeserializeObject<List<Pizza>>(sr.ReadToEnd());
                        }
                        Console.WriteLine("Id ni daxil edin ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Pizza pizza = pizzas.Find(pizza => pizza.Id == id);
                        if (pizza != null)
                        {
                            PizzaMethods.PizzaDescription(id);
                        }
                        else if (pizza == null)
                        {
                            Console.WriteLine("Yanlis id,zehmet olmasa duzgun secim edin");
                            goto Pizza;
                        }
                        exit:
                        Console.WriteLine("\nElave etmek isteyirsinizse S e basin");
                        Console.WriteLine("geri qayitmaq ucun E ye basin");
                        string key = Console.ReadLine();
                        if (key == "S" || key == "s")
                        {
                            Console.WriteLine("sebete elave olundu");
                            price += pizza.Price;
                            goto Pizza;
                        }
                        else if (key == "E" || key == "e")
                        {
                            goto Menu;
                        }
                        else
                        {
                            Console.WriteLine("yanlis daxil edirsiniz");
                            goto exit;
                        }
                    case 2:
                        if (price > 0)
                        {
                            Console.WriteLine("Sifaris meblegi");
                            Console.WriteLine(price);
                            Console.WriteLine("tesdiqlemek ucun nomre ve unvani qeyd edin");
                            Console.WriteLine("input phone");
                            string phone = Console.ReadLine();
                            Console.WriteLine("input adress");
                            string adress = Console.ReadLine();
                            price = 0;
                            Console.WriteLine("Sifaris verildi");
                            goto Menu;
                        }
                        else if (price == 0)
                        {
                            Console.WriteLine("siz hecne sifaris etmemisiniz ");
                            Console.WriteLine("Zehmet olmasa menyudan pizzalara baxib secim edin");
                            goto Menu;
                        }
                        break;
                    default:
                        Console.WriteLine("zehmet olasa duzgun daxil edin");
                        goto Menu;
                }
            }
        }
        public static void AdminMenu()
        {
        Input:
            Console.WriteLine("\n1.Pizzalara bax \n2.Sifariş ver  \n3. Pizzalar \n4.Userler");
            Console.WriteLine("Please input key ");
            int key = Convert.ToInt32(Console.ReadLine());
            switch (key)
            {
                case 1:
                Pizza:
                    PizzaMethods.PrintPizza();

                    List<Pizza> pizzas;
                    using (StreamReader sr = new StreamReader("C:\\Users\\HP\\Desktop\\PizzaProject\\PizzaProject\\Files\\Products.json"))
                    {
                        pizzas = JsonConvert.DeserializeObject<List<Pizza>>(sr.ReadToEnd());
                    }
                    Console.WriteLine("Id ni daxil edin ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Pizza pizza = pizzas.Find(pizza => pizza.Id == id);
                    if (pizza != null)
                    {
                        PizzaMethods.PizzaDescription(id);
                    }
                    else if (pizza == null)
                    {
                        Console.WriteLine("Yanlis id,zehmet olmasa duzgun secim edin");
                        goto Pizza;
                    }
                Add:
                    Console.WriteLine("\nElave etmek isteyirsinizse S e basin");
                    Console.WriteLine("yeniden pizza elave etmek ucun P e basin");
                    Console.WriteLine("geri qayitmaq ucun E ye basin");
                    string input = Console.ReadLine();
                    if (input == "S" || input == "s")
                    {
                        Console.WriteLine("sebete elave olundu");
                        price += pizza.Price;
                        goto Pizza;
                    }
                    else if (input=="E" || input=="e")
                    {
                        AdminMenu();
                    }
                    else if (input == "P" || input == "p")
                    {
                        goto Pizza;
                    }
                    else
                    {
                        Console.WriteLine("yanlis daxil edirsiniz");
                        goto Add;
                    }
                    break;

                case 2:
                    if (price > 0)
                    {
                        Console.WriteLine("Sifaris meblegi");
                        Console.WriteLine(price);
                        Console.WriteLine("tesdiqlemek ucun nomre ve unvani qeyd edin");
                        Console.WriteLine("input phone");
                        string phone = Console.ReadLine();
                        Console.WriteLine("input adress");
                        string adress = Console.ReadLine();
                        Console.WriteLine("Sifaris verildi");
                        price = 0;
                        AdminMenu();
                    }
                    else if (price == 0)
                    {
                        Console.WriteLine("siz hecne sifaris etmemisiniz ");
                        Console.WriteLine("Zehmet olmasa menyudan pizzalara baxib secim edin");
                        AdminMenu();
                    }
                    break;
                case 3:
                    PizzaCrud.PizzaCrudMenu();
                    break;
                case 4:
                    UserCrud.UserCrudMenu();
                    break;
                default:
                    Console.WriteLine("Zehmet olmasa duzgun daxil edin");
                    goto Input;
            }
        }
    }
}