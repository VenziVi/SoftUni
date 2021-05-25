using System;

namespace PadwanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double amount = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double lightsabersPrice = double.Parse(Console.ReadLine());
            double robesPrice = double.Parse(Console.ReadLine());
            double beltsPrice = double.Parse(Console.ReadLine());

            double moneyNeeded = 1;

            moneyNeeded = Math.Ceiling(students * 1.1) * lightsabersPrice;
            moneyNeeded += students * robesPrice;
            moneyNeeded += Math.Abs((students / 6) - students) * beltsPrice;

            if (moneyNeeded <= amount)
            {
                Console.WriteLine($"The money is enough - it would cost {moneyNeeded:f2}lv.");
            }
            else
            {
                double neededMoney = moneyNeeded - amount;
                Console.WriteLine($"Ivan Cho will need {neededMoney:f2}lv more.");
            }
        }
    }
}
