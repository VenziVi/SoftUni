using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfInteger
{
    public class Box<T>
    {
        public T Value { get; set; }

        public override string ToString()
        {
            string print = $"{Value.GetType()}: {Value}";
            return print;
        }
    }
}

