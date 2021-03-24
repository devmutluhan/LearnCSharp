using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Product
    {
        public double Price { get; set; }
        public string Name { get; set; }

        public Product(double price, string name)
        {
            this.Price = price;
            this.Name = name;
        }

        public Product()
        {
          
        }

        public double sadeceKdv()
        { 
            return Price * 0.10;
        }

    }

}
