using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = SingletonDataContainer.Instance;
            Console.WriteLine(db.GetPopulation("London"));
            var db1 = SingletonDataContainer.Instance;
            Console.WriteLine(db1.GetPopulation("Sofia"));
        }
    }
}
