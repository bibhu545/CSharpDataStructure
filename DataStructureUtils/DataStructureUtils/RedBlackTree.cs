using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureUtils
{
    public class RedBlackTree<Key, Value>
        where Key : IComparable
    {
        public class Node
        {
            public Key key;
            public Value val;
            public Node parent;
            public Node left;
            public Node right;
            public int color;
        }
        public Node root;
        public Node nullNode;
        /// <summary>
        /// Pre-Order Traversal of Tree(root->left->right) 
        /// </summary>
        /// <param name="node">Node of Tree</param>
        public void PreOrderTraversal(Node node)
        {
            if (node != nullNode)
            {
                String Color = node.color == 1 ? "RED" : "BLACK";
                Console.WriteLine("Key:" + node.key + "\tValue:" + node.val + "\tColor:" + Color + "\n");
                PreOrderTraversal(node.left);
                PreOrderTraversal(node.right);
            }
        }
        /// <summary>
        /// In-Order Traversal of Tree(left->root->right)
        /// </summary>
        /// <param name="node">Node of Tree</param>
        public void InOrderTraversal(Node node)
        {
            if (node != nullNode)
            {
                InOrderTraversal(node.left);
                String Color = node.color == 1 ? "RED" : "BLACK";
                Console.WriteLine("Key:" + node.key + "\tValue:" + node.val + "\tColor:" + Color);
                InOrderTraversal(node.right);
            }
        }
        /// <summary>
        /// Post-Order Traversal of Tree(left->right->root)
        /// </summary>
        /// <param name="node">Node of Tree</param>
        public void PostOrderTraversal(Node node)
        {
            if (node != nullNode)
            {
                PostOrderTraversal(node.left);
                PostOrderTraversal(node.right);
                String Color = node.color == 1 ? "RED" : "BLACK";
                Console.WriteLine("Key:" + node.key + "\tValue:" + node.val + "\tColor:" + Color);
            }
        }
        /// <summary>
        /// Fixing Red Black Tree Properties after Deleting a Node
        /// </summary>
        /// <param name="node">Node of Tree</param>
        public void FixDelete(Node node)
        {
            Node temporaryNode;
            while (node != root && node.color == 0)
            {
                if (node == node.parent.left)
                {
                    temporaryNode = node.parent.right;
                    if (temporaryNode.color == 1)
                    {
                        temporaryNode.color = 0;
                        node.parent.color = 1;
                        LeftRotate(node.parent);
                        temporaryNode = node.parent.right;
                    }
                    if (temporaryNode.left.color == 0 && temporaryNode.right.color == 0)
                    {
                        temporaryNode.color = 1;
                        node = node.parent;

                    }
                    else
                    {
                        if (temporaryNode.right.color == 0)
                        {
                            temporaryNode.left.color = 0;
                            temporaryNode.color = 1;
                            RightRotate(temporaryNode);
                            temporaryNode = node.parent.right;
                        }
                        temporaryNode.color = node.parent.color;
                        node.parent.color = 0;
                        temporaryNode.right.color = 0;
                        LeftRotate(node.parent);
                        node = root;
                    }
                }
                else
                {
                    temporaryNode = node.parent.left;
                    if (temporaryNode.color == 1)
                    {
                        temporaryNode.color = 0;
                        node.parent.color = 1;
                        RightRotate(node.parent);
                        temporaryNode = node.parent.left;
                    }
                    if (temporaryNode.left.color == 0 && temporaryNode.right.color == 0)
                    {
                        temporaryNode.color = 1;
                        node = node.parent;
                        return;

                    }
                    else
                    {
                        if (temporaryNode.left.color == 0)
                        {
                            temporaryNode.right.color = 0;
                            temporaryNode.color = 1;
                            LeftRotate(temporaryNode);
                            temporaryNode = node.parent.left;
                        }
                        temporaryNode.color = node.parent.color;
                        node.parent.color = 0;
                        temporaryNode.left.color = 0;
                        RightRotate(node.parent);
                        node = root;
                    }
                }
            }
            node.color = 0;
        }
        /// <summary>
        /// Altering Red Black Tree Nodes after Deletion
        /// </summary>
        /// <param name="nodeBeingDeleted">Node to be Deleted</param>
        /// <param name="siblingNode">Node to be Fixed after Deletion</param>
        public void RbTransplant(Node nodeBeingDeleted, Node siblingNode)
        {
            if (nodeBeingDeleted.parent == null)
            {
                root = siblingNode;
            }
            else if (nodeBeingDeleted == nodeBeingDeleted.parent.left)
            {
                nodeBeingDeleted.parent.left = siblingNode;
            }
            else
            {
                nodeBeingDeleted.parent.right = siblingNode;
            }
            siblingNode.parent = nodeBeingDeleted.parent;
        }
        /// <summary>
        /// Red Black Tree Node Deletion
        /// </summary>
        /// <param name="node">Root Node</param>
        /// <param name="currentNodeData">Key of the Node which is to be Deleted</param>
        public void DeleteTreeNode(Node node, Key currentNodeData)
        {
            Node nodeToBeDeleted = nullNode;
            Node temporaryNode, temporaryNodeToBeDeleted;
            int compareValue;
            while (node != nullNode)
            {
                compareValue = node.key.CompareTo(currentNodeData);
                if (compareValue == 0)
                {
                    nodeToBeDeleted = node;
                }
                if (compareValue < 0)
                {
                    node = node.right;
                }
                else
                {
                    node = node.left;
                }
            }
            if (nodeToBeDeleted == nullNode)
            {
                Console.WriteLine("Node is not found in the tree");
                return;
            }
            temporaryNodeToBeDeleted = nodeToBeDeleted;
            int nodeBeingDeletedOriginalColor = temporaryNodeToBeDeleted.color;
            if (nodeToBeDeleted.left == nullNode)
            {
                temporaryNode = nodeToBeDeleted.right;
                RbTransplant(nodeToBeDeleted, nodeToBeDeleted.right);
            }
            else if (nodeToBeDeleted.right == nullNode)
            {
                temporaryNode = nodeToBeDeleted.left;
                RbTransplant(nodeToBeDeleted, nodeToBeDeleted.left);
            }
            else
            {
                temporaryNodeToBeDeleted = FindMinimumNode(nodeToBeDeleted.right);
                nodeBeingDeletedOriginalColor = temporaryNodeToBeDeleted.color;
                temporaryNode = temporaryNodeToBeDeleted.right;
                if (temporaryNodeToBeDeleted.parent == nodeToBeDeleted)
                {
                    temporaryNode.parent = temporaryNodeToBeDeleted;
                }
                else
                {
                    RbTransplant(temporaryNodeToBeDeleted, temporaryNodeToBeDeleted.right);
                    temporaryNodeToBeDeleted.right = nodeToBeDeleted.right;
                    temporaryNodeToBeDeleted.right.parent = temporaryNodeToBeDeleted;
                }
                RbTransplant(nodeToBeDeleted, temporaryNodeToBeDeleted);
                temporaryNodeToBeDeleted.left = nodeToBeDeleted.left;
                temporaryNodeToBeDeleted.left.parent = temporaryNodeToBeDeleted;
                temporaryNodeToBeDeleted.color = nodeToBeDeleted.color;
            }
            if (nodeBeingDeletedOriginalColor == 0)
            {
                FixDelete(temporaryNode);
            }
        }
        /// <summary>
        /// Fixing Red Black Tree Properties after Inserting a Node
        /// </summary>
        /// <param name="currentNode">Node to be Fixed after Insertion</param>
        private void FixInsert(Node currentNode)
        {
            Node temporaryNode;
            while (currentNode.parent.color == 1)
            {
                if (currentNode.parent == currentNode.parent.parent.right)
                {
                    temporaryNode = currentNode.parent.parent.left;
                    if (temporaryNode.color == 1)
                    {
                        temporaryNode.color = 0;
                        currentNode.parent.color = 0;
                        currentNode.parent.parent.color = 1;
                        currentNode = currentNode.parent.parent;
                    }
                    else
                    {
                        if (currentNode == currentNode.parent.left)
                        {
                            currentNode = currentNode.parent;
                            RightRotate(currentNode);
                        }
                        currentNode.parent.color = 0;
                        currentNode.parent.parent.color = 1;
                        LeftRotate(currentNode.parent.parent);
                    }
                }
                else
                {
                    temporaryNode = currentNode.parent.parent.right;
                    if (temporaryNode.color == 1)
                    {
                        temporaryNode.color = 0;
                        currentNode.parent.color = 0;
                        currentNode.parent.parent.color = 1;
                        currentNode = currentNode.parent.parent;
                    }
                    else
                    {
                        if (currentNode == currentNode.parent.right)
                        {
                            currentNode = currentNode.parent;
                            LeftRotate(currentNode);
                        }
                        currentNode.parent.color = 0;
                        currentNode.parent.parent.color = 1;
                        RightRotate(currentNode.parent.parent);
                    }
                }
                if (currentNode == root)
                {
                    break;
                }
            }
            root.color = 0;
        }
        /// <summary>
        /// Initialization of a Red Black Tree
        /// </summary>     
        public RedBlackTree()
        {
            nullNode = new Node();
            nullNode.color = 0;
            nullNode.left = null;
            nullNode.right = null;
            root = nullNode;
        }
        /// <summary>
        ///     Calling Pre-Order Traversal Method
        /// </summary>
        public void Preorder()
        {
            PreOrderTraversal(this.root);
        }
        /// <summary>
        ///     Calling In-Order Traversal Method
        /// </summary>
        public void Inorder()
        {
            InOrderTraversal(this.root);
        }
        /// <summary>
        ///     Calling Post-Order Traversal Method
        /// </summary>
        public void Postorder()
        {
            PostOrderTraversal(this.root);
        }
        /// <summary>
        ///     Find minimum Node in Right of nodeToBeDeleted(Used in Fixing the Properties After Deletion) 
        /// </summary>
        /// <param name="node">Node to the Right of nodeToBeDeleted</param>
        public Node FindMinimumNode(Node node)
        {
            while (node.left != nullNode)
            {
                node = node.left;
            }
            return node;
        }
        /// <summary>
        ///     Left Rotation of Tree 
        /// </summary>
        /// <param name="node">Node on which Rotation is to be done.</param>
        public void LeftRotate(Node node)
        {
            Node temporaryNode = node.right;
            node.right = temporaryNode.left;
            if (temporaryNode.left != nullNode)
            {
                temporaryNode.left.parent = node;
            }
            temporaryNode.parent = node.parent;
            if (node.parent == null)
            {
                this.root = temporaryNode;
            }
            else if (node == node.parent.left)
            {
                node.parent.left = temporaryNode;
            }
            else
            {
                node.parent.right = temporaryNode;
            }
            temporaryNode.left = node;
            node.parent = temporaryNode;
        }
        /// <summary>
        ///     Right Rotation of Tree 
        /// </summary>
        /// <param name="node">Node on which Rotation is to be done.</param>
        public void RightRotate(Node node)
        {
            Node temporaryNode = node.left;
            node.left = temporaryNode.right;
            if (temporaryNode.right != nullNode)
            {
                temporaryNode.right.parent = node;
            }
            temporaryNode.parent = node.parent;
            if (node.parent == null)
            {
                this.root = temporaryNode;
            }
            else if (node == node.parent.right)
            {
                node.parent.right = temporaryNode;
            }
            else
            {
                node.parent.left = temporaryNode;
            }
            temporaryNode.right = node;
            node.parent = temporaryNode;
        }
        /// <summary>
        ///     Insertion on New Node in the Tree
        /// </summary>
        /// <param name="newNodeKey">Key of new Node</param>
        /// <param name="newNodeValue">Value of the new Node</param>
        public void Insert(Key newNodeKey, Value newNodeValue)
        {
            Node newNode = new Node();
            newNode.parent = null;
            newNode.key = newNodeKey;
            newNode.val = newNodeValue;
            newNode.left = nullNode;
            newNode.right = nullNode;
            newNode.color = 1;
            Node node = null;
            Node temporaryNode = this.root;
            int comparisonValue;
            while (temporaryNode != nullNode)
            {
                node = temporaryNode;
                comparisonValue = newNode.key.CompareTo(temporaryNode.key);
                if (comparisonValue < 0)
                {
                    temporaryNode = temporaryNode.left;
                }
                else if (comparisonValue > 0)
                    temporaryNode = temporaryNode.right;
                else if (comparisonValue == 0) //This key already exists, exit without adding it
                    return;

            }
            newNode.parent = node;

            if (node == null)
            {
                root = newNode;
            }
            else
            {
                comparisonValue = newNode.key.CompareTo(node.key);
                if (comparisonValue < 0)
                {
                    node.left = newNode;
                }
                else if (comparisonValue > 0)
                {
                    node.right = newNode;
                }
                else if (comparisonValue == 0)//This key already exists, exit without adding it
                {
                    return;
                }
            }
            if (newNode.parent == null)
            {
                newNode.color = 0;
                return;
            }
            if (newNode.parent.parent == null)
            {
                return;
            }
            FixInsert(newNode);
        }
        /// <summary>
        ///     Calling Deletion Method on Tree
        /// </summary>
        /// <param name="currentNodeData">Key of Node which is to be Deleted</param>
        public void DeleteNode(Key currentNodeData)
        {
            DeleteTreeNode(this.root, currentNodeData);
        }

    }

}
