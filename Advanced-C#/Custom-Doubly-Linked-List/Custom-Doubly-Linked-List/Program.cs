using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList list = new DoublyLinkedList();
            list.AddFirst(5);
            list.AddFirst(8);
            list.AddFirst(3);
            list.AddFirst(4);
            list.AddFirst(9);
            list.RemoveFirst();
            list.ForEach(x => Console.WriteLine(x));
        }
    }
}
