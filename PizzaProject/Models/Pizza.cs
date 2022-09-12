using PizzaProject.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaProject.Models
{
    class Pizza
    {
        private string _name;
        private double _price;
        private string _description;

        public string Name { get=>_name;
            set
            {
                if (value.Length>0)
                {
                    _name = value;
                }
            }
            
        }
       public double Price
        {
            get => _price;
            set
            {
                if (value > 0)
                {
                    _price = value;
                }
            }
        }
        public string Description {
            get => _description;
            set {
                    _description = value;
                }
               
                

            } 
        public int Id { get; set; }
     
    }
}
