using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotoFinder.Models
{
    public enum Brand
    {
        HONDA,
        YAMAHA,
        KAWASAKI,
        SUZUKI
    }

    public enum License
    {
        A1,
        A2,
        A2_A,
        A
    }

    public enum Type
    {
        NAKED,
        SPORT,
        ADVENTURE,
        SUPERMOTO,
        CAFE,
        ENDURO,
    }

    public class Bike
    {
        public Bike(string name, string cc, string hp, string torque, string weight, string cylinders, string price, Type type, License license, Brand brand)
        {
            this.name = name;
            this.cc = Convert.ToInt32(cc);
            this.hp = Convert.ToInt32(hp);
            this.torque = Convert.ToInt32(torque);
            this.weight = Convert.ToInt32(weight);
            this.cylinders = Convert.ToInt32(cylinders);
            this.price = Convert.ToInt32(price);
            this.type = type;
            this.license = license;
            this.brand = brand;
        }

        public string name { get; set; }
        public int cc { get; set; }
        public int hp { get; set; }
        public int torque { get; set; }
        public int weight { get; set; }

        public int cylinders { get; set; }
        public int price { get; set; }
        public Type type { get; set; }
        public License license { get; set; }
        public Brand brand { get; set; }
    }
}
