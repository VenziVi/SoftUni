using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodStrings
{
    public class Box<T>
    {
        
        public void Swap(List<T> list, int firstIndex, int secondIndex)
        {
            var first = list[firstIndex];
            var second = list[secondIndex];
            list[firstIndex] = second;
            list[secondIndex] = first;
        }
    }
}
