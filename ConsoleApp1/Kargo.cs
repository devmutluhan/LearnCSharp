using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Cargo
    {
        public string Name { get; set; }
        public double Ücret { get; set; }
        public Cargo(string name, double ücret)
        {
            this.Name = name;
            this.Ücret = ücret;
        }
    }
}
