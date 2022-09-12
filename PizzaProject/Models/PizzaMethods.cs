using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PizzaProject.Models
{
    class PizzaMethods
    {

        public static void PizzaReader()
        {
            List<Pizza> pizzas;
            using (StreamReader sr = new StreamReader("C:\\Users\\HP\\Desktop\\PizzaProject\\PizzaProject\\Files\\Products.json"))
            {
                pizzas = JsonConvert.DeserializeObject<List<Pizza>>(sr.ReadToEnd());
            }
        }
        public static void AddPizza(string name, float price, string description)
        {
            List<Pizza> pizzas;
            using (StreamReader sr = new StreamReader("C:\\Users\\HP\\Desktop\\PizzaProject\\PizzaProject\\Files\\Products.json"))
            {
                pizzas = JsonConvert.DeserializeObject<List<Pizza>>(sr.ReadToEnd());
            }          
            Pizza pizza = pizzas.FindLast(pizza => pizza.Id == pizza.Id);
            int id = pizza.Id + 1;
            pizzas.Add(new Pizza()
            {
                Name = name,
                Price = price,
                Description = description,
                Id = id,
            }
        ) ;
            using (StreamWriter sw = new StreamWriter("C:\\Users\\HP\\Desktop\\PizzaProject\\PizzaProject\\Files\\Products.json"))
            {
                sw.Write(JsonConvert.SerializeObject(pizzas));
            }
        }
        public static void PrintPizza()
        {
            List<Pizza> pizzas;
            using (StreamReader sr = new StreamReader("C:\\Users\\HP\\Desktop\\PizzaProject\\PizzaProject\\Files\\Products.json"))
            {
                pizzas = JsonConvert.DeserializeObject<List<Pizza>>(sr.ReadToEnd());
            }

            foreach (Pizza item in pizzas)
            {
                Console.WriteLine("\nName:" + item.Name + "\nId:" + item.Id);
            }
           
        }
        public static void PizzaDescription(int id)
        {
            List<Pizza> pizzas;
            using (StreamReader sr = new StreamReader("C:\\Users\\HP\\Desktop\\PizzaProject\\PizzaProject\\Files\\Products.json"))
            {
                pizzas = JsonConvert.DeserializeObject<List<Pizza>>(sr.ReadToEnd());
            }
            foreach (Pizza item in pizzas)
            {
                if (item.Id == id)
                {
                    Console.WriteLine("\nDescription" + "\n" + item.Description);
                }
            }
        }
    }
}
