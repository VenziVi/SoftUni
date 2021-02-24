using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList
    {


        public class ListNode
        {
            public int Value { get; set; }

            public ListNode NextNode { get; set; }

            public ListNode PreviousNode { get; set; }

            public ListNode(int value)
            {
                Value = value;
            }
        }

        private ListNode head;
        private ListNode tail;

        public int Count { get; private set; }

        public void AddFirst(int element)
        {
            if (Count == 0)
            {
                head = tail = new ListNode(element);
            }
            else
            {
                var newHead = new ListNode(element);
                newHead.NextNode = head;
                head.PreviousNode = newHead;
                head = newHead;
            }

            Count++;
        }

        public void AddLast(int element)
        {
            if (Count == 0)
            {
                tail = head = new ListNode(element);
            }
            else
            {
                var newTail = new ListNode(element);
                newTail.PreviousNode = tail;
                tail.NextNode = newTail;
                tail = newTail;
            }

            Count++;
        }

        public int RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            var firstElement = head.Value;
            head = head.NextNode;

            if (head != null)
            {
                head.PreviousNode = null;
            }
            else
            {
                tail = null;
            }

            Count--;

            return firstElement;
        }

        public int RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            var removedTail = tail.Value;
            tail = tail.PreviousNode;

            if (tail != null)
            {
                tail.NextNode = null;
            }
            else
            {
                head = null;
            }

            Count--;
            return removedTail;
        }

        public void ForEach(Action<int> action)
        {
            var currNode = head;
            while (currNode != null)
            {
                action(currNode.Value);
                currNode = currNode.NextNode;
            }
        }

        public int[] ToArray()
        {
            int[] array = new int[Count];
            int counter = 0;
            var firstElement = head;
            while (firstElement != null)
            {
                array[counter] = firstElement.Value;
                firstElement = firstElement.NextNode;
                counter++;
            }

            return array;
        }

    }
}
