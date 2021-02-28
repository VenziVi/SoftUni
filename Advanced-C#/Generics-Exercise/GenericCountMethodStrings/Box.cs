using System;
using System.Collections;
using System.Collections.Generic;


namespace GenericCountMethodStrings
{
    public class Box<T> where T : IComparable
    {
        public int CountMethod(List<T> list, T element)
        {
            int count = 0;

            foreach (var item in list)
            {
                if (item.CompareTo(element) == 1)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
