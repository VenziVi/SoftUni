using System;
using System.Collections.Generic;
using System.Text;

namespace _01ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> list;
        private int index;
        public ListyIterator(List<T> list)
        {
            this.list = list;
            this.index = 0;
        }

        public bool Move()
        {
            if (HasNext())
            {
                index++;
                return true;
            }
            return false;
        }

        public void Print()
        {
            if (this.index >= this.list.Count)
            {
                throw new IndexOutOfRangeException("Invalid Operation!");
            }

            Console.WriteLine(list[index]);
        }

        public bool HasNext() => this.index < this.list.Count - 1;
    }
}
