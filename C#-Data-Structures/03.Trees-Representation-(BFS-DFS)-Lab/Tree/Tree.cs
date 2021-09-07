namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;

        public Tree(T value)
        {
            this.Value = value;
            this.Parent = null;
            this.children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (Tree<T> child in children)
            {
                child.Parent = this;
                this.children.Add(child);
            }
        }

        public T Value { get; private set; }

        public Tree<T> Parent { get; private set; }

        public bool IsRootDeleted { get; private set; }
        
        public IReadOnlyCollection<Tree<T>> Children => this.children.AsReadOnly();

        public ICollection<T> OrderBfs()
        {
            if (IsRootDeleted)
            {
                return new List<T>();
            }

            var result = new List<T>();
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count != 0)
            {
                var node = queue.Dequeue();

                result.Add(node.Value);

                foreach (var child in node.children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public ICollection<T> OrderDfs()
        {
            if (IsRootDeleted)
            {
                return new List<T>();
            }

            var result = new List<T>();

            this.DFS(this, result);

            return result;
        }      

        public void AddChild(T parentKey, Tree<T> child)
        {
            if (this.Value.Equals(parentKey))
            {
                this.children.Add(child);
                child.Parent = this;
                return;
            }

            Tree<T> currNode = this.FindBFS(parentKey);

            CheckEmptyNode(currNode);

            currNode.AddChild(parentKey, child);
        }       

        public void RemoveNode(T nodeKey)
        {
            Tree<T> currNode = this.FindBFS(nodeKey);
            CheckEmptyNode(currNode);

            if (currNode.Parent == null)
            {
                currNode.children.Clear();
                IsRootDeleted = true;
                currNode.Value = default;
            }
            else
            {
                currNode.Parent.REmoveChild(currNode);
            }

        }
       
        public void Swap(T firstKey, T secondKey)
        {
            Tree<T> firstNode = FindBFS(firstKey);
            Tree<T> secondNode = FindBFS(secondKey);

            CheckEmptyNode(firstNode);
            CheckEmptyNode(secondNode);

            if (firstNode.Parent == null)
            {
                SwapRoot(secondNode);
                return;
            }

            else if (secondNode.Parent == null)
            {
                SwapRoot(firstNode);
                return;
            }

            Tree<T> firstParentNode = firstNode.Parent;
            Tree<T> secondParentNode = secondNode.Parent;

            int indexOfFirstNode = firstParentNode.children.IndexOf(firstNode);
            int indexOfSecondNode = secondParentNode.children.IndexOf(secondNode);

            firstNode.Parent = secondNode.Parent;
            secondNode.Parent = firstNode.Parent;

            firstParentNode.children[indexOfFirstNode] = secondNode;
            secondParentNode.children[indexOfSecondNode] = firstNode;
        }

        private void SwapRoot(Tree<T> secondNode)
        {
            T value = secondNode.Value;

            this.Value = value;
            this.children.Clear();

            foreach (var child in secondNode.children)
            {
                this.children.Add(child);
            }

            return;
        }

        private void DFS(Tree<T> tree, List<T> result)
        {
            foreach (var child in tree.Children)
            {
                DFS(child, result);
            }

            result.Add(tree.Value);
        }

        private void CheckEmptyNode(Tree<T> currNode)
        {
            if (currNode == null)
            {
                throw new ArgumentNullException();
            }
        }

        private Tree<T> FindBFS(T parentKey)
        {
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count != 0)
            {
                var currNode = queue.Dequeue();

                if (currNode.Value.Equals(parentKey))
                {
                    return currNode;
                }

                foreach (var child in currNode.children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        private bool REmoveChild(Tree<T> node)
        {
            node.Parent = null;

            foreach (var child in node.children)
            {
                child.Parent = null;
            }

            return this.children.Remove(node);
        }
    }
}
