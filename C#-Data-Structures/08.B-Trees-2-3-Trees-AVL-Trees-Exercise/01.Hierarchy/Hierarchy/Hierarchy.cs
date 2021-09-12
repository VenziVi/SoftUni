namespace _01.Hierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;

    public class Hierarchy<T> : IHierarchy<T>
    {
        private class Node
        {
            public T Value { get; set; }
            public List<Node> Children { get; set; }

            public Node(T value)
            {
                this.Value = value;
                this.Children = new List<Node>();
            }
        }

        private Node root;
        private Dictionary<T, Node> parentByChildValue;
        private Dictionary<T, Node> nodesByValue;

        public Hierarchy(T value)
        {
            this.parentByChildValue = new Dictionary<T, Node>();
            this.nodesByValue = new Dictionary<T, Node>();
            this.root = new Node(value);
            this.nodesByValue.Add(value, this.root);
            this.parentByChildValue.Add(value, null);
        }

        public int Count 
        {
            get
            {
                return nodesByValue.Count;
            }
        }

        public void Add(T element, T child)
        {
            if (!nodesByValue.ContainsKey(element) ||
                nodesByValue.ContainsKey(child))
            {
                throw new ArgumentException();
            }

            var childNode = new Node(child);
            this.nodesByValue.Add(child, childNode);
            this.parentByChildValue.Add(child, this.nodesByValue[element]);
            this.nodesByValue[element].Children.Add(childNode);
        }

        public void Remove(T element)
        {
            if (element.Equals(this.root.Value))
            {
                throw new InvalidOperationException();
            }
            else if (!nodesByValue.ContainsKey(element))
            {
                throw new ArgumentException();
            }

            var parentNode = this.parentByChildValue[element];
            var node = this.nodesByValue[element];

            parentNode.Children.Remove(node);
            parentNode.Children.AddRange(node.Children);

            foreach (var child in node.Children)
            {
                this.parentByChildValue[child.Value] = parentNode;
            }

            this.nodesByValue.Remove(element);
            this.parentByChildValue.Remove(element);

        }

        public IEnumerable<T> GetChildren(T element)
        {
            if (!this.nodesByValue.ContainsKey(element))
            {
                throw new ArgumentException();
            }

            return nodesByValue[element]
                .Children
                .Select(Node => Node.Value);
        }

        public T GetParent(T element)
        {
            
            if (!this.nodesByValue.ContainsKey(element))
            {
                throw new ArgumentException();
            }

            var parentElement = this.parentByChildValue[element];

            if (parentElement == null)
            {
                return default;
            }

            return parentElement.Value;
        }

        public bool Contains(T element)
        {
            return this.nodesByValue.ContainsKey(element);
        }

        public IEnumerable<T> GetCommonElements(Hierarchy<T> other)
        {
            var common = new List<T>();

            foreach (var key in nodesByValue.Keys)
            {
                if (other.Contains(key))
                {
                    common.Add(key);
                }
            }
            return common;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var queue = new Queue<Node>();
            queue.Enqueue(this.root);

            while (queue.Count != 0)
            {
                var node = queue.Dequeue();

                yield return node.Value;

                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}