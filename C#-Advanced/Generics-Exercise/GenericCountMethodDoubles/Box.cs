using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericCountMethodDoubles
{
    public class Box<T>
    {
        public int CountMethod(List<double> list, double element)
        {
            list = list.Where(x => x > element).ToList();
            
            return list.Count;
        }
    }
}
