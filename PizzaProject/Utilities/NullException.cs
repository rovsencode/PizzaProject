using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaProject.Utilities
{
    class NullException:Exception
    {
   
        public NullException(string message):base(message)
        {
            Console.WriteLine(message);
        }
    }
}
