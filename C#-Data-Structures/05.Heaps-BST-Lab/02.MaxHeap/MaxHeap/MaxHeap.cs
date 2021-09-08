namespace _02.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> heap;

        public MaxHeap()
        {
            this.heap = new List<T>();
        }

        public int Size { get { return this.heap.Count; } }

        public void Add(T element)
        {
            this.heap.Add(element);
            Heapify(this.heap.Count - 1);
        }
        
        public T Peek()
        {
            if (this.heap.Count == 0)
            {
                throw new InvalidOperationException();
            }
            return heap[0];
        }

        private void Heapify(int index)
        {
            if (index == 0) return;
            int parentIndex = (index - 1) / 2;

            if (heap[index].CompareTo(heap[parentIndex]) > 0)
            {
                var temp = heap[index];
                heap[index] = heap[parentIndex];
                heap[parentIndex] = temp;
                Heapify(parentIndex);
            }
        }
    }
}
