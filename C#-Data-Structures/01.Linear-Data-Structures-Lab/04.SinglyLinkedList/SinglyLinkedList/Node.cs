namespace Problem04.SinglyLinkedList
{
    public class Node<T>
    {
        public Node(T value, Node<T> next, Node<T> previous)
        {
            this.Value = value;
            this.Next = next;
            this.Previous = previous;

        }
        public T Value { get; set; }

        public Node<T> Next { get; set; }

        public Node<T> Previous { get; set; }
    }
}