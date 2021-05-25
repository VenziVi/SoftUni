using System;

namespace BoxOfT
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<string> media = new Box<string>();

            media.Add("ivan");
            media.Add("stoqn");
            media.Add("drago");
            Console.WriteLine(media.Remove());
            media.Add("baio");
            media.Add("mimi");
            Console.WriteLine(media.Remove());;
        }
    }
}
