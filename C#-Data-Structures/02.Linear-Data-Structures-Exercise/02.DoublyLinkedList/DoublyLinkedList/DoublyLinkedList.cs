namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var node = new Node<T>(item, null, null);
            if (this.Count == 0)
            {
                this.head = this.tail = node;
                this.Count++;
                return;
            }
            var oldHead = this.head;
            oldHead.Previous = node;
            this.head = node;
            this.head.Next = oldHead;
            this.Count++;
        }

        public void AddLast(T item)
        {
            var node = new Node<T>(item, null, null);
            if (this.Count == 0)
            {
                this.head = this.tail = node;
                this.Count++;
                return;
            }
            node.Previous = this.tail;
            this.tail.Next = node;
            this.tail = node;
            this.Count++;
        }

        public T GetFirst()
        {
            this.ValidateCollection();

            return this.head.Item;
        }

        public T GetLast()
        {
            this.ValidateCollection();

            return this.tail.Item;
        }

        public T RemoveFirst()
        {
            this.ValidateCollection();

            var node = this.head;
            this.head = this.head.Next;
            this.Count--;
            return node.Item;
        }

        public T RemoveLast()
        {
            this.ValidateCollection();

            var node = this.tail;
            this.tail = node.Previous;
            this.Count--;
            return node.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.head;

            while (node.Next != null)
            {
                yield return node.Item;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void ValidateCollection()
        {
            if (this.Count == 0) throw new InvalidOperationException();
        }
    }
}