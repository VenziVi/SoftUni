namespace _01.BSTOperations
{
    using System;
    using System.Collections.Generic;

    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {
        public BinarySearchTree()
        {
        }

        public BinarySearchTree(Node<T> root)
        {
            this.Root = root;
            this.LeftChild = Root.LeftChild;
            this.RightChild = Root.RightChild;
        }

        public Node<T> Root { get; private set; }

        public Node<T> LeftChild { get; private set; }

        public Node<T> RightChild { get; private set; }

        public int Count { get; private set; }

        public bool Contains(T element)
        {
            if (this.Root.Value.CompareTo(element) == 0)
            {
                return true;
            }

            var node = SearchDfs(this.Root, element);

            return node != null;
        }

        public void Insert(T element)
        {
            this.Root = Insert(this.Root, element);
        }

        public IAbstractBinarySearchTree<T> Search(T element)
        {
            if (this.Root.Value.Equals(element))
            {
                return this;
            }

            return SearchDfs(this.Root, element);
        }

        public void EachInOrder(Action<T> action)
        {
            DfsINOrder(this.Root, action);
        }

        public List<T> Range(T lower, T upper)
        {
            var result = new List<T>();

            InRange(this.Root, lower, upper, result);

            return result;
        }

        public void DeleteMin()
        {
            IsEmpty(this.Root);

            if (this.Root.LeftChild == null)
            {
                this.Root = this.Root.RightChild;
                return;
            }

            var node = this.Root;

            while (node.LeftChild.LeftChild != null)
            {
                node = node.LeftChild;
            }

            node.LeftChild = node.LeftChild.RightChild;
            this.Count--;
        }

        public void DeleteMax()
        {
            IsEmpty(this.Root);

            if (this.Root.RightChild == null)
            {
                this.Root = this.Root.LeftChild;
                return;
            }

            var node = this.Root;

            while (node.RightChild.RightChild != null)
            {
                node = node.RightChild;
            }

            node.RightChild = node.RightChild.LeftChild;
            this.Count--;
        }

        public int GetRank(T element)
        {
            return GetRankCount(this.Root, element);
        }

        private int GetRankCount(Node<T> node, T element)
        {

            if (node == null)
            {
                return 0;
            }

            int count = 0;

            if (node.Value.CompareTo(element) < 0)
            {
                count++;
            }

            if (node.LeftChild != null)
            {
                count += GetRankCount(node.LeftChild, element);
            }
            if (node.RightChild != null)
            {
                count += GetRankCount(node.RightChild, element);
            }

            return count;
        }

        private IAbstractBinarySearchTree<T> SearchDfs(Node<T> node, T element)
        {
            if (node == null)
            {
                return null;
            }
            if (node.Value.Equals(element))
            {
                BinarySearchTree<T> newNode = new BinarySearchTree<T>(node);
                return newNode;
            }
            if (node.Value.CompareTo(element) < 0)
            {
                return SearchDfs(node.RightChild, element);
            }
            else
            {
                return SearchDfs(node.LeftChild, element);
            }
        }

        private Node<T> Insert(Node<T> node, T element)
        {
            if (node == null)
            {
                node = new Node<T>(element, null, null);
                this.Count++;
                return node;
            }
            else if (node.Value.CompareTo(element) < 0)
            {
                node.RightChild = Insert(node.RightChild, element);
            }
            else
            {
                node.LeftChild = Insert(node.LeftChild, element);
            }

            return node;
        }

        private void DfsINOrder(Node<T> root, Action<T> action)
        {
            if (root == null)
            {
                return;
            }

            DfsINOrder(root.LeftChild, action);

            action(root.Value);

            DfsINOrder(root.RightChild, action);
        }

        private void InRange(Node<T> node, T lower, T upper, List<T> result)
        {
            if (node == null)
            {
                return;
            }

            if (node.Value.CompareTo(lower) >= 0 && node.Value.CompareTo(upper) <= 0)
            {
                result.Add(node.Value);
            }

            InRange(node.LeftChild, lower, upper, result);
            InRange(node.RightChild, lower, upper, result);
        }

        private void IsEmpty(Node<T> root)
        {
            if (root == null) throw new InvalidOperationException();
        }
    }
}
