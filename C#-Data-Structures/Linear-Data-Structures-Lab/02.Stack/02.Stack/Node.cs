namespace Problem02.Stack
{
    public class Node<T>
    {
        public T Value { get; set; }

        public Node<T> Previous { get; set; }
    }
}