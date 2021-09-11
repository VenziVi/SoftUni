namespace _03.MinHeap
{
    using System;
    using System.Collections.Generic;

    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> elements;

        public MinHeap()
        {
            this.elements = new List<T>();
        }

        public int Size => elements.Count;

        public T Dequeue()
        {
            ValidateIfEmpty();

            var result = elements[0];
            elements.RemoveAt(0);

            return result;
        }

        public void Add(T element)
        {
            elements.Add(element);


            int startIndex = this.Size - 1;

            while (startIndex != 0 && elements[startIndex].CompareTo(elements[startIndex - 1]) == -1)
            {
                var temp = elements[startIndex - 1];
                elements[startIndex - 1] = elements[startIndex];
                elements[startIndex] = temp;

                startIndex--;
            }
        }

        public T Peek()
        {
            ValidateIfEmpty();

            return elements[0];
        }

        private void ValidateIfEmpty()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}