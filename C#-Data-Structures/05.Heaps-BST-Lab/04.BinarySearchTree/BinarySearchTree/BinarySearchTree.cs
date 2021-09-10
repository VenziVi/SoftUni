namespace _04.BinarySearchTree
{
    using System;

    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {
        public BinarySearchTree()
        {
        }

        public BinarySearchTree(Node<T> root)
        {
            this.Root = root;
            this.LeftChild = root.LeftChild;
            this.RightChild = root.RightChild;
        }

        public Node<T> Root { get; private set; }

        public Node<T> LeftChild { get; private set; }

        public Node<T> RightChild { get; private set; }

        public T Value => this.Root.Value;

        public bool Contains(T element)
        {
            return Contains(this.Root, element);
        }

        public void Insert(T element)
        {
            if (this.Root == null)
            {
                this.Root = new Node<T>(element, null, null);
                return;
            }
            else
            { 
                Insert(this.Root, element);
            }
        }
        
        public IAbstractBinarySearchTree<T> Search(T element)
        {
            return Search(this.Root, element);
        }

        private IAbstractBinarySearchTree<T> Search(Node<T> node, T element)
        {
            if (node == null) return null;

            if (node.Value.CompareTo(element) == 0)
            {
                return new BinarySearchTree<T>(node);
            }

            if (element.CompareTo(node.Value) < 0)
            {
                return Search(node.LeftChild, element);
            }
            else
            {
                return Search(node.RightChild, element);
            }
        }

        private Node<T> Insert(Node<T> node, T element)
        {
            if (node == null)
            {
                return new Node<T>(element, null, null);
            }

            if (element.CompareTo(node.Value) == -1)
            {
                node.LeftChild = Insert(node.LeftChild, element);

            }
            else if (element.CompareTo(node.Value) == 1)
            {
                node.RightChild = Insert(node.RightChild, element);
            }

            return node;
        }

        private bool Contains(Node<T> node, T element)
        {
            if (node == null) return false;

            if (node.Value.CompareTo(element) == 0) return true;

            if (element.CompareTo(node.Value) >= 0)
            {
                return Contains(node.RightChild, element);
            }
            else
            {
                return Contains(node.LeftChild, element);
            }
        }
    }
}
