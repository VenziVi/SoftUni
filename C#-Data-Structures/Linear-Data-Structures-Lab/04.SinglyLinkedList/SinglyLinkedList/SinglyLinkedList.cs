namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newNode = new Node<T>(item, null, null);
            if (this.Count > 0)
            {
                newNode.Next = this.head;
                this.head.Previous = newNode;
                this.head = newNode;
                this.Count++;
                return;
            }

            this.CreateFirstNode(newNode);
        }

        public void AddLast(T item)
        {
            var newNode = new Node<T>(item, null, null);
            if (this.Count > 0)
            {
                newNode.Previous = this.tail;
                this.tail.Next = newNode;
                this.tail = newNode;
                this.Count++;
                return;
            }

            this.CreateFirstNode(newNode);
        }

        public T GetFirst()
        {
            this.Validate();
            return this.head.Value;
        }

        public T GetLast()
        {
            this.Validate();
            return this.tail.Value;
        }

        public T RemoveFirst()
        {
            this.Validate();
            var currNode = this.head;
            this.head = this.head.Next;
            this.Count--;
            return currNode.Value;
        }

        public T RemoveLast()
        {
            this.Validate();
            var currNode = this.tail;
            this.tail = this.tail.Previous;
            this.Count--;
            return currNode.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.head;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void Validate()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }

        private void CreateFirstNode(Node<T> newNode)
        {
            this.head = this.tail = newNode;
            Count++;
            return;
        }
    }
}