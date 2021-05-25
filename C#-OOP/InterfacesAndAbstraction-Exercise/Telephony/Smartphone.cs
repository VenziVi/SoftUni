using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : ISmartphone
    {
        public void Browsing(string URl)
        {
            Console.WriteLine($"Browsing: {URl}!");
        }

        public void Calling(string number)
        {
            Console.WriteLine($"Calling... {number}");
        }
    }
}
