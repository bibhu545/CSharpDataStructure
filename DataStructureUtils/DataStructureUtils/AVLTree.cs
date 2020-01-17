using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureUtils
{
    public class AVLTree<T> where T : IComparable<T>
    {
        public class Node
        {
            public T key;
            public int height;
            public Node left, right;

            public Node(T d)
            {
                key = d;
                height = 1;
            }
        }

        public Node root;

        /// <summary>
        /// To get the height of Tree
        /// </summary>
        /// <param name="N"></param>
        /// <returns>Height</returns>
        static int height(Node N)
        {
            if (N == null)
                return 0;

            return N.height;
        }


        /// <summary>
        /// Function to get max of two integers
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>max value</returns>
        static int max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        /// <summary>
        /// Function to right rotate subtree
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        static Node rightRotate(Node y)
        {
            Node x = y.left;
            Node T2 = x.right;

            // Perform rotation  
            x.right = y;
            y.left = T2;

            // Update heights  
            y.height = max(height(y.left),
                        height(y.right)) + 1;
            x.height = max(height(x.left),
                        height(x.right)) + 1;

            // Return new root  
            return x;
        }

        /// <summary>
        /// function t left rotate subtree
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        static Node leftRotate(Node x)
        {
            Node y = x.right;
            Node T2 = y.left;

            // Perform rotation  
            y.left = x;
            x.right = T2;

            // Update heights  
            x.height = max(height(x.left),
                        height(x.right)) + 1;
            y.height = max(height(y.left),
                        height(y.right)) + 1;

            // Return new root  
            return y;
        }

        /// <summary>
        /// function to get balance factor of node
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        static int getBalance(Node N)
        {
            if (N == null)
                return 0;

            return height(N.left) - height(N.right);
        }

        /// <summary>
        /// funtion to Insert Root and new Nodes in AVL Tree
        /// </summary>
        /// <param name="node"></param>
        /// <param name="key"></param>
        /// <returns>Node</returns>
        public static Node Insert(Node node, T key)
        {

            if (node == null)
            {
                Node n = new Node(key);
                return n;
            }
                

            if (key.CompareTo(node.key) < 0)
                node.left = Insert(node.left, key);
            else if (key.CompareTo(node.key) > 0)
                node.right = Insert(node.right, key);
            else
                return node;

            node.height = 1 + max(height(node.left),
                                height(node.right));

            int balance = getBalance(node);

            if (balance > 1 && key.CompareTo(node.left.key) < 0)
                return rightRotate(node);

            if (balance < -1 && key.CompareTo(node.right.key) > 0)
                return leftRotate(node);

            if (balance > 1 && key.CompareTo(node.left.key) < 0)
            {
                node.left = leftRotate(node.left);
                return rightRotate(node);
            }

            if (balance < -1 && key.CompareTo(node.right.key) < 0)
            {
                node.right = rightRotate(node.right);
                return leftRotate(node);
            }

            return node;
        }

        /// <summary>
        /// function to return minvalue of node
        /// </summary>
        /// <param name="node"></param>
        /// <returns>Node</returns>
        static Node minValueNode(Node node)
        {
            Node current = node;

            /* loop down to find the leftmost leaf */
            while (current.left != null)
                current = current.left;

            return current;
        }


        /// <summary>
        /// To Delete a Particular Node using key value
        /// </summary>
        /// <param name="root"></param>
        /// <param name="key"></param>
        /// <returns>Root of AVL(Node)</returns>
        public static Node deleteNode(Node root, T key)
        {  
            if (root == null)
                return root;

            if (key.CompareTo(root.key) < 0)
                root.left = deleteNode(root.left, key);

            else if (key.CompareTo(root.key) > 0)
                root.right = deleteNode(root.right, key);

            else
            {

                if ((root.left == null) || (root.right == null))
                {
                    Node temp = null;
                    if (temp == root.left)
                        temp = root.right;
                    else
                        temp = root.left;

                    if (temp == null)
                    {
                        temp = root;
                        root = null;
                    }
                    else 
                        root = temp; 
                }
                else
                {
                    Node temp = minValueNode(root.right);

                    root.key = temp.key;

                    root.right = deleteNode(root.right, temp.key);
                }
            }

            if (root == null)
                return root;

            root.height = max(height(root.left),
                        height(root.right)) + 1;
 
            int balance = getBalance(root);

            if (balance > 1 && getBalance(root.left) >= 0)
                return rightRotate(root);

            // Left Right Case  
            if (balance > 1 && getBalance(root.left) < 0)
            {
                root.left = leftRotate(root.left);
                return rightRotate(root);
            }

            // Right Right Case  
            if (balance < -1 && getBalance(root.right) <= 0)
                return leftRotate(root);

            // Right Left Case  
            if (balance < -1 && getBalance(root.right) > 0)
            {
                root.right = rightRotate(root.right);
                return leftRotate(root);
            }

            return root;
        }

        /// <summary>
        /// PreOrder Traversal of AVL Tree
        /// </summary>
        /// <param name="node"></param>
        public static void preOrder(Node node)
        {
            if (node != null)
            {
                Console.Write(node.key + " ");
                preOrder(node.left);
                preOrder(node.right);
            }
        }
    }

    public class AVLTreeCall
    {
        /// <summary>
        /// AVL Tree Instion of Integers
        /// </summary>
        /// <param name="root"></param>
        /// <param name="item"></param>
        /// <returns>Node</returns>
        public static AVLTree<int>.Node AVLTreeInsertItems(AVLTree<int>.Node root, int item)
        {
            AVLTree<int>.Node node = AVLTree<int>.Insert(root, item);
            return node;
        }
        /// <summary>
        /// AVL Tree Instion of Doubles
        /// </summary>
        /// <param name="root"></param>
        /// <param name="item"></param>
        /// <returns>Node</returns>
        public static AVLTree<double>.Node AVLTreeInsertItems(AVLTree<double>.Node root, double item)
        {
            AVLTree<double>.Node node = AVLTree<double>.Insert(root, item);
            return node;
        }
        /// <summary>
        /// AVL Tree Instion of Strings
        /// </summary>
        /// <param name="root"></param>
        /// <param name="item"></param>
        /// <returns>Node</returns>
        public static AVLTree<string>.Node AVLTreeInsertItems(AVLTree<string>.Node root, string item)
        {
            AVLTree<string>.Node node = AVLTree<string>.Insert(root, item);
            return node;
        }
        /// <summary>
        /// AVL Tree Instion of Characters
        /// </summary>
        /// <param name="root"></param>
        /// <param name="item"></param>
        /// <returns>Node</returns>
        public static AVLTree<char>.Node AVLTreeInsertItems(AVLTree<char>.Node root, char item)
        {
            AVLTree<char>.Node node = AVLTree<char>.Insert(root, item);
            return node;
        }


        /// <summary>
        /// PreOrder Traversal of Interger AVLTree
        /// </summary>
        /// <param name="root"></param>
        public static void AVLPreOrder(AVLTree<int>.Node root)
        {
            AVLTree<int>.preOrder(root);
        }

        /// <summary>
        /// PreOrder Traversal of Character AVLTree
        /// </summary>
        /// <param name="root"></param>
        public static void AVLPreOrder(AVLTree<char>.Node root)
        {
            AVLTree<char>.preOrder(root);
        }

        /// <summary>
        /// PreOrder Traversal of String AVLTree
        /// </summary>
        /// <param name="root"></param>
        public static void AVLPreOrder(AVLTree<string>.Node root)
        {
            AVLTree<string>.preOrder(root);
        }

        /// <summary>
        /// PreOrder Traversal of Double AVLTree
        /// </summary>
        /// <param name="root"></param>
        public static void AVLPreOrder(AVLTree<double>.Node root)
        {
            AVLTree<double>.preOrder(root);
        }

        /// <summary>
        /// function to delete Interger item from AVL Tree
        /// </summary>
        /// <param name="root"></param>
        /// <param name="item"></param>
        /// <returns>Root Node</returns>
        public static AVLTree<int>.Node AVLTreeDelete(AVLTree<int>.Node root, int item)
        {
            AVLTree<int>.Node node = AVLTree<int>.deleteNode(root, item);
            return node;
        }

        /// <summary>
        /// function to delete Character item from AVL Tree
        /// </summary>
        /// <param name="root"></param>
        /// <param name="item"></param>
        /// <returns>Root Node</returns>
        public static AVLTree<char>.Node AVLTreeDelete(AVLTree<char>.Node root, char item)
        {
            AVLTree<char>.Node node = AVLTree<char>.deleteNode(root, item);
            return node;
        }

        /// <summary>
        /// function to delete Character item from AVL Tree
        /// </summary>
        /// <param name="root"></param>
        /// <param name="item"></param>
        /// <returns>Root Node</returns>
        public static AVLTree<double>.Node AVLTreeDelete(AVLTree<double>.Node root, double item)
        {
            AVLTree<double>.Node node = AVLTree<double>.deleteNode(root, item);
            return node;
        }

        /// <summary>
        /// function to delete String item from AVL Tree
        /// </summary>
        /// <param name="root"></param>
        /// <param name="item"></param>
        /// <returns>Root Node</returns>
        public static AVLTree<string>.Node AVLTreeDelete(AVLTree<string>.Node root, string item)
        {
            AVLTree<string>.Node node = AVLTree<string>.deleteNode(root, item);
            return node;
        }
    }

}
