namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TreeFactory
    {
        private Dictionary<int, Tree<int>> nodesBykeys;

        public TreeFactory()
        {
            this.nodesBykeys = new Dictionary<int, Tree<int>>();
        }

        public Tree<int> CreateTreeFromStrings(string[] input)
        {
            foreach (var line in input)
            {
                int[] args = line.Split().Select(int.Parse).ToArray();
                int parent = args[0];
                int child = args[1];

                this.CreateNodeByKey(parent);
                this.CreateNodeByKey(child);
                this.AddEdge(parent, child);
            }

            return GetRoot();
        }

        public Tree<int> CreateNodeByKey(int key)
        {
            if (!this.nodesBykeys.ContainsKey(key))
            {
                this.nodesBykeys.Add(key, new Tree<int>(key));
            }

            return this.nodesBykeys[key];
        }

        public void AddEdge(int parent, int child)
        {
            var parentNode = this.nodesBykeys[parent];
            var childNode = this.nodesBykeys[child];

            parentNode.AddChild(childNode);
            childNode.AddParent(parentNode);
        }

        private Tree<int> GetRoot()
        {
            foreach (var subtree in this.nodesBykeys.Values)
            {
                if (subtree.Parent == null)
                {
                    return subtree;
                }
            }

            return null;
        }
    }
}
