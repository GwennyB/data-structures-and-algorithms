﻿using System;
using tree.Classes;

namespace FindAncestry
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool ancestor = IsAncestor(BuildBinTree(), 3,6);
            Console.WriteLine($"This should be TRUE: {ancestor}");

            ancestor = IsAncestor(BuildBinTree(), 5, 15);
            Console.WriteLine($"This should be FALSE: {ancestor}");

            Console.ReadLine();
        }

        /// <summary>
        /// initiates recursive search for ancestor (one) and successor (two)
        /// </summary>
        /// <param name="tree"> tree to search </param>
        /// <param name="one"> potential ancestor to locate </param>
        /// <param name="two"> potential successor to locate </param>
        /// <returns></returns>
        public static bool IsAncestor(BinaryTree tree, int one, int two)
        {
            if(tree.Root == null || (tree.Root.Left == null && tree.Root.Right == null))
            {
                return false;
            }
            return FindA(tree.Root, one, two);
        }

        /// <summary>
        /// locates a potential ancestor, and intiates recursive search under it for potential successor
        /// </summary>
        /// <param name="node"> root of (sub-)tree to search </param>
        /// <param name="one"> potential ancestor to locate </param>
        /// <param name="two"> potential successor to locate </param>
        /// <returns></returns>
        public static bool FindA(Node node, int one, int two)
        {
            bool answer = false;
            if (node.Value == one)
            {
                if (node.Left != null)
                {
                    if (FindB(node.Left, two, answer))
                    {
                        return true;
                    }
                }
                if (node.Right != null)
                {
                    if (FindB(node.Right, two, answer))
                    {
                        return true;
                    }
                }
            }
            else
            {
                if (node.Left != null)
                {
                    if (FindA(node.Left, one, two))
                    {
                        return true;
                    }
                }
                if (node.Right != null)
                {
                    if(FindA(node.Right, one, two))
                    {
                        return true;
                    }
                }
            }
            return answer;
        }

        /// <summary>
        /// locates a potential successor; aborts and returns 'true' if found
        /// </summary>
        /// <param name="node"></param>
        /// <param name="two"></param>
        /// <returns></returns>
        public static bool FindB(Node node, int two, bool answer)
        {
            if(answer == true || node.Value == two)
            {
                return true;
            }
            else
            {
                if (node.Left != null)
                {
                    if (FindB(node.Left, two, answer))
                    {
                        return true;
                    }
                }
                if (node.Right != null)
                {
                    if (FindB(node.Right, two, answer))
                    {
                        return true;
                    }
                }
            }
            return answer;
        }

        /// <summary>
        /// populates BinaryTree of height=7 for testing
        /// </summary>
        /// <param name="tree"> tree to populate</param>
        /// <returns> populated tree </returns>
        public static BinaryTree BuildBinTree()
        {
            BinaryTree tree = new BinaryTree();
            tree.Root = new Node(1);
            tree.Root.Left = new Node(2);
            tree.Root.Right = new Node(3);
            tree.Root.Left.Left = new Node(4);
            tree.Root.Left.Right = new Node(5);
            tree.Root.Right.Left = new Node(6);
            tree.Root.Right.Left.Left = new Node(7);
            tree.Root.Right.Left.Right = new Node(8);
            tree.Root.Right.Right = new Node(9);
            tree.Root.Right.Right.Left = new Node(10);
            tree.Root.Right.Right.Right = new Node(11);
            tree.Root.Right.Right.Right.Left = new Node(12);
            tree.Root.Right.Right.Right.Right = new Node(13);
            tree.Root.Right.Right.Right.Right.Left = new Node(14);
            tree.Root.Right.Right.Right.Right.Right = new Node(15);
            tree.Root.Right.Right.Right.Right.Right = new Node(16);
            tree.Root.Right.Right.Right.Right.Right.Left = new Node(17);
            tree.Root.Right.Right.Right.Right.Right.Left.Right = new Node(18);
            return tree;
        }
    }
}
