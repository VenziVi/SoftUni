namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T value
            , IAbstractBinaryTree<T> leftChild
            , IAbstractBinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public T Value { get; private set; }

        public IAbstractBinaryTree<T> LeftChild { get; private set; }

        public IAbstractBinaryTree<T> RightChild { get; private set; }

        public string AsIndentedPreOrder(int indent)
        {
            StringBuilder result = new StringBuilder();

            AsIndentedPreOrder(this, result, indent);

            return result.ToString().Trim();
        }
        
        public List<IAbstractBinaryTree<T>> InOrder()
        {
            var result = new List<IAbstractBinaryTree<T>>();

            InOrder(this, result);

            return result;
        }
       
        public List<IAbstractBinaryTree<T>> PostOrder()
        {
            var result = new List<IAbstractBinaryTree<T>>();

            PostOrder(this, result);

            return result;
        }
        
        public List<IAbstractBinaryTree<T>> PreOrder()
        {
            var result = new List<IAbstractBinaryTree<T>>();

            PreOrder(this, result);

            return result;
        }
       
        public void ForEachInOrder(Action<T> action)
        {
            if (this.LeftChild != null)
            {
                this.LeftChild.ForEachInOrder(action);
            }

            action.Invoke(Value);

            if (this.RightChild != null)
            {
                this.RightChild.ForEachInOrder(action);
            }
        }

        private void AsIndentedPreOrder(IAbstractBinaryTree<T> node, StringBuilder result, int indent)
        {
            result.AppendLine($"{new string(' ', indent)}{node.Value}");

            if (node.LeftChild != null)
            {
                AsIndentedPreOrder(node.LeftChild, result, indent + 2);
            }
            if (node.RightChild != null)
            {
                AsIndentedPreOrder(node.RightChild, result, indent + 2);
            }
        }

        private void InOrder(IAbstractBinaryTree<T> node, List<IAbstractBinaryTree<T>> result)
        {
            if (node.LeftChild != null)
            {
                InOrder(node.LeftChild, result);
            }

            result.Add(node);

            if (node.RightChild != null)
            {
                InOrder(node.RightChild, result);
            }
        }

        private void PostOrder(IAbstractBinaryTree<T> node, List<IAbstractBinaryTree<T>> result)
        {
            if (node.LeftChild != null)
            {
                PostOrder(node.LeftChild, result);
            }
            if (node.RightChild != null)
            {
                PostOrder(node.RightChild, result);
            }

            result.Add(node);
        }

        private void PreOrder(IAbstractBinaryTree<T> node, List<IAbstractBinaryTree<T>> result)
        {
            if (node != null)
            {
                result.Add(node);
                PreOrder(node.LeftChild, result);
                PreOrder(node.RightChild, result);
            }
        }
    }
}
