using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _01ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> list;
        private int index;
        public ListyIterator(List<T> list)
        {
            this.list = list;
            this.index = 0;
        }
        // 10 20 30

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

        public bool HasNext()
        {
            if (this.index == this.list.Count - 1)
            {
                return false;
            }
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.list)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal void PrintAll()
        {
            if (list.Count > 0)
            {
                Console.WriteLine(string.Join(" ", list));
            }
            else
            {
                throw new IndexOutOfRangeException("Invalid Operation!");
            }
        }
    }
}
