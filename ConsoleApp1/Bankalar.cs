using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Banks
    {
        public string Name { get; set; }
        public double Komisyonoranı { get; set; }
        public Banks(string name, double komisyonoranı)
        {
            this.Name = name;
            this.Komisyonoranı = komisyonoranı;
        }

        public double getKomisyon(double price)
        {
            double getkomisyon = price * Komisyonoranı;
            return getkomisyon;
        }

    }
    

}
