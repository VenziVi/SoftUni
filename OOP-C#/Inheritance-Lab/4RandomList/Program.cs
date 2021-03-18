using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();
            list.Add("joro");
            list.Add("koko");
            list.Add("moko");
            list.Add("boko");
            list.Add("skip");

            Console.WriteLine(list.RandomString());           
        }
    }
}
