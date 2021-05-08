using System;

namespace TemplatePattern
{
    class StartUp
    {
        static void Main(string[] args)
        {
            TwelvGrain twelvGrain = new TwelvGrain();
            twelvGrain.make();

            Console.WriteLine("----------------------------");
            
            WholeWheat wholeWheat = new WholeWheat();
            wholeWheat.make();
        }
    }
}
