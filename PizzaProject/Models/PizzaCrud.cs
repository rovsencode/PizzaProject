using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PizzaProject.Models
{
    class PizzaCrud
    {
        public static void PizzaCrudMenu()
        {
            try {
                Console.WriteLine("\n1.Hamısına bax \n2.Elave \n3.Duzeliş et \n4.Sil");
                Console.WriteLine("please input");
                int key = Convert.ToInt32(Console.ReadLine());
                switch (key)
                {

                    case 1:
                        PizzaMethods.PrintPizza();
                    Pizza:
                        Console.WriteLine("Id ni daxil edin ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        List<Pizza> pizzas;
                        using (StreamReader sr = new StreamReader("C:\\Users\\HP\\Desktop\\PizzaProject\\PizzaProject\\Files\\Products.json"))
                        {
                            pizzas = JsonConvert.DeserializeObject<List<Pizza>>(sr.ReadToEnd());
                        }
                        Pizza pizza = pizzas.Find(pizza => pizza.Id == id);
                        if (pizza != null)
                            PizzaMethods.PizzaDescription(id);
                        else if (pizza == null)
                        {
                            Console.WriteLine("Yanlis id,zehmet olmasa duzgun secim edin");
                            goto Pizza;
                        }
                    exit:
                        Console.WriteLine("geri qayitmaq ucun 0 a basin");
                        int exit = Convert.ToInt32(Console.ReadLine());
                        if (exit == 0)
                            PizzaCrudMenu();
                        else
                            goto exit;
                        break;
                    case 2:
                        Add:
                        Console.WriteLine("pizzanin adini daxil edin");
                        string namep = Console.ReadLine();
                        Console.WriteLine("pizzanin qiymetini daxil edin");
                        float pricep = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Zehmet olmasa pizzanin icindekiler qeyd edin");
                        string description = Console.ReadLine();
                        using (StreamReader sr = new StreamReader("C:\\Users\\HP\\Desktop\\PizzaProject\\PizzaProject\\Files\\Products.json"))
                        {
                            pizzas = JsonConvert.DeserializeObject<List<Pizza>>(sr.ReadToEnd());
                        }
                        pizza = pizzas.Find(pizza => pizza.Name == namep);
                        if (pizza==null)
                        {
                            PizzaMethods.AddPizza(namep, pricep, description);
                            goto exit;
                        }
                       else
                        {
                            Console.WriteLine("bele bir pizza movcuddur");
                            goto Add;
                        }
                    case 3:
                        Console.WriteLine("deyismek istediyiniz pizzanin id sini daxil edin");
                        int keyid = Convert.ToInt32(Console.ReadLine());

                        using (StreamReader sr = new StreamReader("C:\\Users\\HP\\Desktop\\PizzaProject\\PizzaProject\\Files\\Products.json"))
                        {
                            pizzas = JsonConvert.DeserializeObject<List<Pizza>>(sr.ReadToEnd());
                        }
                         pizza = pizzas.Find(_pizza => _pizza.Id == keyid);
                        if (pizza != null)
                        {
                        PizzaChange:
                            Console.WriteLine("neyi deyismek isteyirsiniz? \nName-ucun N-e  \nPrice-ucun P-ye \nDescription ucun D-ye");
                            string input = Console.ReadLine();
                            if (input == "N" || input=="n")
                            {
                                Console.WriteLine("name daxile edin");
                                string name = Console.ReadLine();
                                pizza.Name = name;
                                using (StreamWriter sw = new StreamWriter("C:\\Users\\HP\\Desktop\\PizzaProject\\PizzaProject\\Files\\Products.json"))
                                {
                                    sw.Write(JsonConvert.SerializeObject(pizzas));
                                }
                                Console.WriteLine("deyisiklik edildi");
                                PizzaCrudMenu();
                            }
                            else if (input == "P" || input=="p")
                            {
                                double price = Convert.ToDouble(Console.ReadLine());
                                pizza.Price = price;
                                using (StreamWriter sw = new StreamWriter("C:\\Users\\HP\\Desktop\\PizzaProject\\PizzaProject\\Files\\Products.json"))
                                {
                                    sw.Write(JsonConvert.SerializeObject(pizzas));
                                }
                                Console.WriteLine("deyisiklik edildi");
                                PizzaCrudMenu();
                            }
                            else if (input == "D" || input=="d")
                            {
                                string _description = Console.ReadLine();
                                pizza.Description = _description;
                                using (StreamWriter sw = new StreamWriter("C:\\Users\\HP\\Desktop\\PizzaProject\\PizzaProject\\Files\\Products.json"))
                                {
                                    sw.Write(JsonConvert.SerializeObject(pizzas));
                                }
                                Console.WriteLine("deyisiklik edildi");
                                PizzaCrudMenu();
                            }
                            else
                            {
                                Console.WriteLine("Duzgun daxil edin deyiseni");
                                goto PizzaChange;
                            }
                        }
                        break;
                    case 4:
                        Console.WriteLine("Silmez istediyiniz pizzanin id sini daxil edin ");
                        keyid = Convert.ToInt32(Console.ReadLine());

                        using (StreamReader sr = new StreamReader("C:\\Users\\HP\\Desktop\\PizzaProject\\PizzaProject\\Files\\Products.json"))
                        {
                            pizzas = JsonConvert.DeserializeObject<List<Pizza>>(sr.ReadToEnd());
                        }
                        pizza = pizzas.Find(_pizza => _pizza.Id == keyid);
                        if (pizza != null)
                            pizzas.Remove(pizza);
                        using (StreamWriter sw = new StreamWriter("C:\\Users\\HP\\Desktop\\PizzaProject\\PizzaProject\\Files\\Products.json"))
                        {
                            sw.Write(JsonConvert.SerializeObject(pizzas));
                        }
                        PizzaCrudMenu();
                        break;
                    default:
                        Console.WriteLine("zehmet olmasa duzgun daxil edin");
                        PizzaCrudMenu();
                        break;
                }
           
                  
            }
            catch(SystemException)
            {
                Console.WriteLine("zehmet olmasa telimatlara duzgun emel edin");
                PizzaCrudMenu();

            }
        }       
        

    }
}
