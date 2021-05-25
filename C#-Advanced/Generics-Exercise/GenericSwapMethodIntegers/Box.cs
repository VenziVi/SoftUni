using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodIntegers
{
    public class Box<T>
    {
        public void Swap(List<T> list, int firstIndex, int secondIndex)
        {
            T first = list[firstIndex];
            T second = list[secondIndex];
            list[firstIndex] = second;
            list[secondIndex] = first;
        }
    }
}
