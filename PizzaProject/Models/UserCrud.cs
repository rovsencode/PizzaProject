using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PizzaProject.Models
{
    class UserCrud
    {
        public static void UserCrudMenu()
        {
            Console.WriteLine("\n1.Hamısına bax \n2.Elave \n3.Duzeliş et \n4.Sil");
            Console.WriteLine("please input key");
            int key = Convert.ToInt32(Console.ReadLine());
            switch (key)
            {
                case 1:
                    UserMethods.PrintUser();
                    Menu:
                    Console.WriteLine("Geri qayitmaq ucun 0 a basin");
                    int input = Convert.ToInt32(Console.ReadLine());
                    if (input==0)
                    {
                        UserCrudMenu();
                    }
                    else
                    {
                        goto Menu;
                    }
                    break;

                case 2:             
                    Console.WriteLine("Name daxil edin ");
                    string name = Console.ReadLine();
                    Console.WriteLine("surname daxil edin");
                    string surname = Console.ReadLine();
                Username:
                    Console.WriteLine("username daxile et");
                    string username = Console.ReadLine();
                password:
                    Console.WriteLine("parolu daxil et");
                    string password = Console.ReadLine();

                    if (User.CheckPassword(password) && username != null)
                    {

                        UserMethods.UserAdd(name, surname, username, password);
                        Console.WriteLine("Xos geldiniz  " + name + " " + surname);
                        Console.WriteLine("Geri qayitmaq ucun 0 a basin");
                         input = Convert.ToInt32(Console.ReadLine());
                        if (input==0)
                        {
                            UserCrudMenu();
                        }
                        else
                        {
                            goto Menu;
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
                case 3:
                    List<User> users;
                    using (StreamReader sr = new StreamReader("c:\\users\\hp\\desktop\\pizzaproject\\pizzaproject\\files\\users.json"))
                    {
                        users = JsonConvert.DeserializeObject<List<User>>(sr.ReadToEnd());
                    }
                    Console.WriteLine("id daxil et");
                    int userid = Convert.ToInt32(Console.ReadLine());
                    User.IsAdmin(userid);
                    User user = users.Find(user => user.Id == userid);
                    if (user.Admin == false)
                    {
                        user.Admin = true;
                        Console.WriteLine(user.Name+"  admin edildi");
                    }
                    else if (user.Admin==true)
                    {
                        user.Admin = false;
                        Console.WriteLine(user.Name+" adminlikden cixarildi");
                    }
                    using (StreamWriter sw = new StreamWriter("c:\\users\\hp\\desktop\\pizzaproject\\pizzaproject\\files\\users.json"))
                    {
                        sw.Write(JsonConvert.SerializeObject(users));
                    }
                    Console.WriteLine("Geri qayitmaq ucun 0 a basin");
                    input = Convert.ToInt32(Console.ReadLine());
                    if (input == 0)
                    {
                        UserCrudMenu();
                    }
                    else
                    {
                        goto Menu;
                    }
                    break;

                case 4:
                    using (StreamReader sr = new StreamReader("c:\\users\\hp\\desktop\\pizzaproject\\pizzaproject\\files\\users.json"))
                    {
                        users = JsonConvert.DeserializeObject<List<User>>(sr.ReadToEnd());
                    }
                    Console.WriteLine("id daxil et");
                    userid = Convert.ToInt32(Console.ReadLine());
                    User userr = users.Find(user => user.Id == userid);
                    if (userr!=null)
                    {
                        users.Remove(userr);
                    }
                    Console.WriteLine(userr.Name+" istifadeci silindi");
                    using (StreamWriter sw = new StreamWriter("c:\\users\\hp\\desktop\\pizzaproject\\pizzaproject\\files\\users.json"))
                    {
                        sw.Write(JsonConvert.SerializeObject(users));
                    }
                    Console.WriteLine("Geri qayitmaq ucun 0 a basin");
                    input = Convert.ToInt32(Console.ReadLine());
                    if (input == 0)
                    {
                        UserCrudMenu();
                    }
                    else
                    {
                        goto Menu;
                    }
                    break;
                default:
                    Console.WriteLine("zehmet olmasa duzgun daxil edin");
                    UserCrudMenu();
                    break;
            }
        }
    }
}
