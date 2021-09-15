namespace _02._AA_Tree
{
    using System;

    public class AATree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        private Node<T> root;
        public int CountNodes()
        {
            return CountNodes(this.root);
        }
      
        public bool IsEmpty()
        {
            return this.root == null;
        }

        public void Clear()
        {
            this.root = null;
        }

        public void Insert(T element)
        {
            this.root = Insert(element, this.root);
        }
        
        public bool Search(T element)
        {
            return Search(this.root, element) == null ? false : true;
        }

        public void InOrder(Action<T> action)
        {
            InOrder(this.root, action);
        }

        public void PreOrder(Action<T> action)
        {
            PreOrder(this.root, action);
        }

        public void PostOrder(Action<T> action)
        {
            PostOrder(this.root, action);
        }

        private void PostOrder(Node<T> node, Action<T> action)
        {
            if (node != null)
            {
                PostOrder(node.Left, action);
                PostOrder(node.Right, action);

                action(node.Element);
            }
        }

        private int CountNodes(Node<T> root)
        {
            if (this.root == null)
            {
                return 0;
            }
            else
            {
                return 1 + CountNodes(this.root.Left) + CountNodes(this.root.Right);
            }
        }

        private Node<T> Insert(T element, Node<T> node)
        {
            if (node == null)
            {
                node = new Node<T>(element);
            }
            else if (element.CompareTo(node.Element) < 0)
            {
                node.Left = Insert(element, node.Left);
            }
            else if (element.CompareTo(node.Element) > 0)
            {
                node.Right = Insert(element, node.Right);
            }

            node = Skew(node);
            node = Split(node);

            return node;
        }

        private Node<T> Split(Node<T> node)
        {
            if (node.Right == null || node.Right.Right == null)
            {
                return node;
            }
            else if (node.Right.Right.Level == node.Level)
            {
                node = Promote(node);
            }
            return node;
        }

        private Node<T> Promote(Node<T> node)
        {
            var newNode = node.Right;
            node.Right = newNode.Left;
            newNode.Left = node;
            newNode.Level++;

            return newNode;
        }

        private Node<T> Skew(Node<T> node)
        {
            if (node.Left != null && node.Left.Level == node.Level)
            {
                node = RotateRight(node);
            }

            return node;
        }

        private Node<T> RotateRight(Node<T> node)
        {
            var newNode = node.Left;
            node.Left = newNode.Right;
            newNode.Right = node;

            return newNode;
        }

        private Node<T> Search(Node<T> node, T element)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Element.Equals(element))
            {
                return node;
            }
            else if (element.CompareTo(node.Element) < 0)
            {
                return Search(node.Left, element);
            }
            else if (element.CompareTo(node.Element) > 0)
            {
                return Search(node.Right, element);
            }
            return null;
        }

        private void InOrder(Node<T> node, Action<T> action)
        {
            if (node != null)
            {
                InOrder(node.Left, action);

                action(node.Element);

                InOrder(node.Right, action);
            }
        }

        private void PreOrder(Node<T> node, Action<T> action)
        {
            if (node != null)
            {
                action(node.Element);

                PreOrder(node.Left, action);
                PreOrder(node.Right, action);
            }
        }
    }
}