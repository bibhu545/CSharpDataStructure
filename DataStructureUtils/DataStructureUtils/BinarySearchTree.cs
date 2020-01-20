
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructureUtils
{
    public enum DepthFirstTraversalMethod
    {
        PreOrder,
        InOrder,
        PostOrder
    }

    public class BinarySearchTree<Tkey> where Tkey : IComparable<Tkey>
    {

        public class BinaryKeyValueNode<Tkey> where Tkey : IComparable<Tkey>
        {
            public Tkey Key { get; set; }
            public BinaryKeyValueNode<Tkey> Parent { get; set; }
            public BinaryKeyValueNode<Tkey> LeftChild { get; set; }
            public BinaryKeyValueNode<Tkey> RightChild { get; set; }
            public BinaryKeyValueNode(Tkey key)
            {
                Key = key;
            }
        }

        private Random random;
        public BinaryKeyValueNode<Tkey> Root { get; set; }
        public int Count { get; protected set; }


        public BinarySearchTree()
        {
            Root = null;
            random = new Random(1);
            Count = 0;
        }

        /// <summary>
        /// Inserts a given Key 
        /// </summary>
        /// <param name="key">Key to be inserted </param>
        /// <returns>void <Tkey></returns>
        public void Insert(Tkey key)
        {
            BinaryKeyValueNode<Tkey> parent = null;
            BinaryKeyValueNode<Tkey> current = Root;
            int compare = 0;
            while (current != null)
            {
                parent = current;
                compare = current.Key.CompareTo(key);
                current = compare < 0 ? current.RightChild : current.LeftChild;
            }
            BinaryKeyValueNode<Tkey> newNode = new BinaryKeyValueNode<Tkey>(key);
            if (parent != null)
                if (compare < 0)
                    parent.RightChild = newNode;
                else
                    parent.LeftChild = newNode;
            else
                Root = newNode;
            newNode.Parent = parent;
            Count++;
        }

        /// <summary>
        /// Finds and deletes an element.
        /// </summary>
        /// <param name="node">Key to be deleted </param>
        /// <returns>void<Tkey></returns>
        public void DeleteKey(Tkey key)
        {
            BinaryKeyValueNode<Tkey> node = FindNode(key);
            DeleteNode(node);
        }
        private void DeleteNode(BinaryKeyValueNode<Tkey> node)
        {
            
            if (node == null)
                throw new ArgumentNullException();
            if (node.LeftChild != null && node.RightChild != null) //2 childs  
            {
                BinaryKeyValueNode<Tkey> replaceBy = random.NextDouble() > .5 ? InOrderSuccesor(node) : InOrderPredecessor(node);
                DeleteNode(replaceBy);
                node.Key = replaceBy.Key;
            }
            else //1 or less childs  
            {
                var child = node.LeftChild == null ? node.RightChild : node.LeftChild;
                if (node.Parent.RightChild == node)
                    node.Parent.RightChild = child;
                else
                    node.Parent.LeftChild = child;
            }
            Count--;
        }

        private BinaryKeyValueNode<Tkey> InOrderSuccesor(BinaryKeyValueNode<Tkey> node)
        {
            BinaryKeyValueNode<Tkey> succesor = node.RightChild;
            while (succesor.LeftChild != null)
                succesor = succesor.LeftChild;
            return succesor;
        }


        private BinaryKeyValueNode<Tkey> InOrderPredecessor(BinaryKeyValueNode<Tkey> node)
        {
            BinaryKeyValueNode<Tkey> succesor = node.LeftChild;
            while (succesor.RightChild != null)
                succesor = succesor.RightChild;
            return succesor;
        }

        /// <summary>
        /// Finds and returns the first matched node.
        /// </summary>
        /// <param name="key">Key to be searched </param>
        /// <returns>Returns Key if found. Returns null if not found.<Tkey></returns>
        public Tkey FindFirstKey(Tkey key)
        {
            return FindNode(key).Key;
        }


        private BinaryKeyValueNode<Tkey> FindNode(Tkey key, bool ExceptionIfKeyNotFound = true)
        {
            BinaryKeyValueNode<Tkey> current = Root;
            while (current != null)
            {
                int compare = current.Key.CompareTo(key);
                if (compare == 0)
                    return current;
                if (compare < 0)
                    current = current.RightChild;
                else
                    current = current.LeftChild;
            }
            return null;
        }


        private IEnumerable<Tkey> TraverseNode(BinaryKeyValueNode<Tkey> node, DepthFirstTraversalMethod method)
        {
            IEnumerable<Tkey> TraverseLeft = node.LeftChild == null ? new Tkey[0] : TraverseNode(node.LeftChild, method),
                TraverseRight = node.RightChild == null ? new Tkey[0] : TraverseNode(node.RightChild, method),
                Self = new Tkey[1] { node.Key };
            switch (method)
            {
                case DepthFirstTraversalMethod.PreOrder:
                    return Self.Concat(TraverseLeft).Concat(TraverseRight);
                case DepthFirstTraversalMethod.InOrder:
                    return TraverseLeft.Concat(Self).Concat(TraverseRight);
                case DepthFirstTraversalMethod.PostOrder:
                    return TraverseLeft.Concat(TraverseRight).Concat(Self);
                default:
                    throw new ArgumentException();
            }
        }

        /// <summary>
        /// Traverses a tree in DFS 
        /// </summary>
        /// <param name="method">DepthFirstTraversalMethod Enum </param>
        /// <returns>Tkey</returns>
        public IEnumerable<Tkey> TraverseTree(DepthFirstTraversalMethod method)
        {
            return TraverseNode(Root, method);
        }

       

    }
}