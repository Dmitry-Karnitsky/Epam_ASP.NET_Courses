using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeProject
{
    public class BinarySearchTree<T> : IEnumerable<T>
    {
        private TreeNode root;
        private IComparer<T> comparer;        

        private class TreeNode
        {
            public TreeNode Parent { get; set; }
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }
            public T Key { get; set; }

            public override string ToString()
            {
                return Key.ToString();
            }
        }

        #region Constructors
        public BinarySearchTree() : this(comparer: null, items: null) { }

        public BinarySearchTree(params T[] items) : this(comparer: null, items: items) { }

        public BinarySearchTree(IComparer<T> comparer) : this(comparer, null) { }

        public BinarySearchTree(Comparison<T> comparison) : this(comparison, null) { }

        public BinarySearchTree(IComparer<T> comparer, params T[] items)
        {
            if (comparer == null)
            {
                this.comparer = TryGetComparer();
                if (this.comparer == null)
                    throw new ArgumentException("Type " + typeof(T).ToString() + "is not implement IComparable interface.");
            }
            else this.comparer = comparer;

            if (items != null)
                foreach (T item in items)
                    Insert(item);
        }

        public BinarySearchTree(Comparison<T> comparison, params T[] items)
        {
            if (comparison == null)
            {
                this.comparer = TryGetComparer();
                if (this.comparer == null)
                    throw new ArgumentException("Type " + typeof(T).ToString() + "is not implement IComparable interface.");
            }
            else this.comparer = new FuncToComparer<T>(comparison);

            if (items != null)
                foreach (T item in items)
                    Insert(item);
        }
        #endregion

        public int Count { get; private set; }

        public T Max 
        { 
            get
            {
                TreeNode temp = root;
                while (temp.Right != null)
                    temp = temp.Right;
                return temp.Key;
            } 
        }

        public T Min
        {
            get
            {
                TreeNode temp = root;
                while (temp.Left != null)
                    temp = temp.Left;
                return temp.Key;
            }
        }

        public bool Insert(T key)
        {
            if (key == null)
                throw new ArgumentNullException("Key to addition was null.");

            if (root == null)
            {
                root = new TreeNode() { Left = null, Right = null, Key = key };
                Count++;
                return true;                
            }

            TreeNode node = FindParent(root, key);

            if (comparer.Compare(node.Key, key) > 0)
            {
                node.Left = new TreeNode() { Left = null, Right = null, Parent = node, Key = key };
                Count++;
                return true;
            }

            if (comparer.Compare(node.Key, key) < 0)
            {
                node.Right = new TreeNode() { Left = null, Right = null, Parent = node, Key = key };
                Count++;
                return true;
            }

            return false;
        }

        public bool Remove(T key)
        {
            if (key == null)
                throw new ArgumentNullException("Key to deletion was null.");

            if (root == null) return false;

            TreeNode node = FindParent(root, key);

            if (comparer.Compare(key, node.Key) == 0)
            {
                if (node.Left == null && node.Right == null)
                    node = null;
                if (node.Left == null && node.Right != null)
                {
                    node.Key = node.Right.Key;
                    node.Left = node.Right.Left;
                    node.Right = node.Right.Right;
                }
                if (node.Left != null && node.Right == null)
                {
                    node.Key = node.Left.Key;
                    node.Left = node.Left.Left;
                    node.Right = node.Left.Right;
                }

                TreeNode temp = node.Left;
                while (temp.Right != null)
                    temp = temp.Right;
                node.Key = temp.Key;
                if (temp.Left != null)
                    temp.Parent.Right = temp.Left;

                Count--;
                return true;
            }
            else return false;
        }

        public bool Find(T key)
        {
            if (key == null)
                throw new ArgumentNullException("Key to deletion was null.");

            if (root == null) return false;

            TreeNode node = FindParent(root, key);

            if (comparer.Compare(key, node.Key) == 0)
                return true;
            else
                return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return InOrderTraversal().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<T> PreOrderTraversal()
        {
            foreach (TreeNode item in GoStraight(root))
                yield return item.Key;
        }

        private IEnumerable<TreeNode> GoStraight(TreeNode root)
        {
            if (root != null)
            {
                yield return root;

                foreach (var node in GoStraight(root.Left))
                {
                    yield return node;
                }

                foreach (var node in GoStraight(root.Right))
                {
                    yield return node;
                }
            }
        }

        public IEnumerable<T> InOrderTraversal()
        {
            foreach (TreeNode item in GoCross(root))
                yield return item.Key;
        }

        private IEnumerable<TreeNode> GoCross(TreeNode root)
        {
            if (root != null)
            {
                foreach (var node in GoCross(root.Left))
                {
                    yield return node;
                }

                yield return root;

                foreach (var node in GoCross(root.Right))
                {
                    yield return node;
                }
            }
        }

        public IEnumerable<T> PostOrderTraversal()
        {
            foreach (TreeNode item in GoReverse(root))
                yield return item.Key;
        }

        private IEnumerable<TreeNode> GoReverse(TreeNode root)
        {
            if (root != null)
            {
                foreach (var node in GoReverse(root.Left))
                {
                    yield return node;
                }

                foreach (var node in GoReverse(root.Right))
                {
                    yield return node;
                }

                yield return root;
            }
        }

        private TreeNode FindParent(TreeNode root, T key)
        {
            int compareResult = comparer.Compare(key, root.Key);

            if (compareResult == 0)
                return root;

            if (compareResult > 0)
            {
                if (root.Right != null)
                    return FindParent(root.Right, key);
                else return root;
            }

            if (compareResult < 0)
            {
                if (root.Left != null)
                    return FindParent(root.Left, key);
                else return root;
            }

            throw new InvalidOperationException("Unable to find parent node.");

        }

        private IComparer<T> TryGetComparer()
        {
            Type t = typeof(T);
            if (typeof(IComparable<T>).IsAssignableFrom(t))
            {
                return comparer = new FuncToComparer<T>((T t1, T t2) => { return ((IComparable<T>)t1).CompareTo(t2); });
            }
            if (typeof(IComparable).IsAssignableFrom(t))
            {
                return comparer = new FuncToComparer<T>((T t1, T t2) => { return ((IComparable)t1).CompareTo(t2); });
            }
            return null;
        }

        public sealed class FuncToComparer<T> : IComparer<T>
        {
            Comparison<T> comparison;

            public FuncToComparer(Comparison<T> comparison)
            {
                this.comparison = comparison;
            }

            public int Compare(T x, T y)
            {
                return comparison(x, y);
            }
        }

    }
}
