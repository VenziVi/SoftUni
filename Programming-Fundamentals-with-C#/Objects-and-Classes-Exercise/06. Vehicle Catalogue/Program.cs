using System;
using System.Text;

namespace _06._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    class Vehicle
    {
        public Vehicle(string type, string model, string colore, string horsePower)
        {
            Type = type;
            Model = model;
            Colore = colore;
            HorsePower = horsePower;
        }

        public string Type { get; set; }

        public string Model { get; set; }

        public string Colore { get; set; }

        public string HorsePower { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Type: {(Type == "car" ? "car" : "Truck")}");
            return
        }
    }

}
