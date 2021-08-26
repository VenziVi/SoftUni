namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private Node<T> top;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var currItem = this.top;

            while (currItem != null)
            {
                if (currItem.Value.Equals(item))
                {
                    return true;
                }

                currItem = currItem.Previous;
            }

            return false;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this.top.Value;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            var item = this.top;
            this.top = top.Previous;
            this.Count--;
            return item.Value;
        }

        public void Push(T item)
        {
            var newItem = new Node<T>();
            newItem.Value = item;

            if (this.Count == 0)
            {
                this.top = newItem;
                this.Count++;
                return;
            }

            newItem.Previous = this.top;
            this.top = newItem;
            this.Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var item = top;

            while (item != null)
            {
                yield return item.Value;

                item = item.Previous;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() 
            => GetEnumerator();
    }
}