namespace _03.PriorityQueue
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> queue;

        public PriorityQueue()
        {
            this.queue = new List<T>();
        }

        public int Size { get { return queue.Count; } }

        public T Dequeue()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException();
            }

            var temp = queue[0];
            queue[0] = queue[this.Size - 1];
            queue.RemoveAt(this.Size - 1);

            HeapifyDown(0);

            return temp;
        }

        public void Add(T element)
        {
            this.queue.Add(element);
            Heapify(this.queue.Count - 1);
        }
        
        public T Peek()
        {
            if (queue.Count == 0)
            {
                throw new InvalidOperationException();
            }
            return queue[0];
        }

        private void Heapify(int index)
        {
            if (index == 0) return;
            int parentIndex = (index - 1) / 2;

            if (queue[index].CompareTo(queue[parentIndex]) > 0)
            {
                var temp = queue[index];
                queue[index] = queue[parentIndex];
                queue[parentIndex] = temp;
                Heapify(parentIndex);
            }
        }

        private void HeapifyDown(int index)
        {
            int leftChild = index * 2 + 1;
            int rightChild = index * 2 + 2;
            int maxChild = leftChild;

            if (leftChild >= queue.Count) return;

            if ((rightChild < queue.Count) && queue[leftChild].CompareTo(queue[rightChild]) < 0)
            {
                maxChild = rightChild;
            }

            if (queue[index].CompareTo(queue[maxChild]) < 0)
            {
                var temp = queue[index];
                queue[index] = queue[maxChild];
                queue[maxChild] = temp;
                HeapifyDown(maxChild);
            }
        }
    }
}
