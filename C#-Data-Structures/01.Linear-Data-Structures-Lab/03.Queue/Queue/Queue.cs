namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var node = this.head;
            while (node != null)
            {
                if (node.Value.Equals(item))
                {
                    return true;
                }
                node = node.Next;
            }

            return false;
        }

        public T Dequeue()
        {
            this.Validate();

            var oldHead = this.head;
            this.head = this.head.Next;
            this.Count--;
            return oldHead.Value;
        }

        public void Enqueue(T item)
        {
            var newNode = new Node<T>(item, null);

            if (this.Count == 0)
            {
                this.head = this.tail = newNode;
                this.Count++;
                return;
            }

            this.tail.Next = newNode;
            this.tail = newNode;
            this.Count++;
        }

        public T Peek()
        {
            this.Validate();

            return this.head.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var item = head;

            while (item != null)
            {
                yield return item.Value;
                item = item.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public void Validate()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}