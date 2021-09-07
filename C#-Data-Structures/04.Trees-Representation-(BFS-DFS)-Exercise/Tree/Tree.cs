namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;

        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            this.children = new List<Tree<T>>();

            foreach (var child in children)
            {
                child.Parent = this;
                this.children.Add(child);
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }


        public IReadOnlyCollection<Tree<T>> Children
            => this.children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this.children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string GetAsString()
        {
            StringBuilder sb = new StringBuilder();

            CreateString(this, sb, 0);

            return sb.ToString().TrimEnd();
        }

        public Tree<T> GetDeepestLeftomostNode()
        {
            var leaves = new List<Tree<T>>();
            Tree<T> deepestNode = null;
            int level = 0;

            DfsGetLievs(this, leaves);

            foreach (var leaf in leaves)
            {
                Tree<T> currNode = leaf;
                int currLevel = 0;

                while (currNode != null)
                {
                    currNode = currNode.Parent;
                    currLevel++;
                }

                if (currLevel > level)
                {
                    level = currLevel;
                    deepestNode = leaf;
                }
            }

            return deepestNode;
        }
      
        public List<T> GetLeafKeys()
        {
            List<T> leaves = new List<T>();
            Func<Tree<T>, bool> predicate = n => n.Children.Count == 0;

            DfsGetKeys(this, leaves, predicate);

            return leaves;
        }

        public List<T> GetMiddleKeys()
        {
            List<T> leafs = new List<T>();

            List<T> middle = new List<T>();
            Func<Tree<T>, bool> predicate = n => n.Children.Count != 0 && n.Parent != null;

            DfsGetKeys(this, middle, predicate);

            return middle;
        }
        
        public List<T> GetLongestPath()
        {
            Tree<T> deepestNode = GetDeepestLeftomostNode();

            List<T> path = new List<T>();

            DfsGetPath(deepestNode, path);

            return path;
        }
       
        public List<List<T>> PathsWithGivenSum(int sum)
        {

            List<Tree<T>> leaves = new List<Tree<T>>();
            List<List<T>> paths = new List<List<T>>();

            DfsGetLeavesNode(this, leaves);

            foreach (var leaf in leaves)
            {
                int currentSum = 0;

                Tree<T> currentLeaf = leaf;
                List<T> path = new List<T>();

                while (currentLeaf != null)
                {
                    currentSum += Convert.ToInt32(currentLeaf.Key);

                    path.Add(currentLeaf.Key);

                    currentLeaf = currentLeaf.Parent;
                }

                if (currentSum == sum)
                {
                    path.Reverse();

                    paths.Add(path);
                }
            }

            return paths;
        }
        
        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            var trees = new List<Tree<T>>();

            AllSubTreesWithSum(this, trees, sum);

            return trees;
        }

        private void AllSubTreesWithSum(Tree<T> tree, List<Tree<T>> result, int expectedSum)
        {
            int totalSum = SubTreesSum(tree, expectedSum);

            if (totalSum == expectedSum)
            {
                result.Add(tree);
            }

            foreach (var child in tree.Children)
            {
                AllSubTreesWithSum(child, result, expectedSum);
            }
        }

        private int SubTreesSum(Tree<T> tree, int expectedSum, int totalSum = 0)
        {
            int sum = int.Parse(tree.Key.ToString());

            foreach (var child in tree.Children)
            {
                sum += int.Parse(child.Key.ToString());
            }

            totalSum += sum;

            if (totalSum < expectedSum)
            {
                foreach (var child in tree.Children)
                {
                    totalSum += SubTreesSum(child, expectedSum, totalSum);
                }
            }
            else if (totalSum == expectedSum)
            {
                return expectedSum;
            }
            else
            {
                return -1;
            }

            return totalSum;
        }

        private void CreateString(Tree<T> tree, StringBuilder sb, int indent)
        {
            sb.AppendLine(new string(' ', indent) + tree.Key);

            foreach (var child in tree.Children)
            {
                CreateString(child, sb, indent + 2);
            }
        }

        private void DfsGetLievs(Tree<T> tree, List<Tree<T>> leaves)
        {
            if (tree.Children.Count == 0)
            {
                leaves.Add(tree);
            }

            foreach (var child in tree.Children)
            {
                DfsGetLievs(child, leaves);
            }
        }

        private void DfsGetKeys(Tree<T> tree, List<T> leaves, Func<Tree<T>, bool> predicate)
        {
            if (predicate(tree))
            {
                leaves.Add(tree.Key);
            }

            foreach (var child in tree.Children)
            {
                DfsGetKeys(child, leaves, predicate);
            }
        }

        private void DfsGetPath(Tree<T> deepestNode, List<T> path)
        {
            while (deepestNode != null)
            {
                path.Add(deepestNode.Key);

                deepestNode = deepestNode.Parent;
            }

            path.Reverse();
        }

        private void DfsGetLeavesNode(Tree<T> tree, List<Tree<T>> leaves)
        {
            if (tree.Children.Count == 0)
            {
                leaves.Add(tree);
            }

            foreach (var child in tree.Children)
            {
                DfsGetLeavesNode(child, leaves);
            }
        }
    }
}
