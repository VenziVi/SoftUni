using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _03Stack
{
    public class MyStack : IEnumerable<int>
    {
        List<int> list;

        public MyStack()
        {
            list = new List<int>();
        }

        public void Push(int element)
        {
            this.list.Add(element);
        }

        public int Pop()
        {
            if (this.list.Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }
            int index = this.list.Count - 1;
            int lastElement = this.list[index];
            this.list.RemoveAt(index);
            return lastElement;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                yield return list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
