using System;
using System.Collections.Generic;
using System.Linq;

namespace interviewPractice
{
    public class TreeNode
    {
        public int val;
        public TreeNode left { get; set; }
        public TreeNode right { get; set; }
        public TreeNode(int x) { val = x; }
    }
    public class Trees
    {
        public IList<int> PreorderTraversal(TreeNode root)
        {
            // for the iterative solution you must use a stack 

            var treeStack = new Stack<TreeNode>();
            var valList = new List<int>();
            if (root == null) return valList;

            while (true)
            {
                if (root != null)
                {
                    valList.Add(root.val);
                    treeStack.Push(root);
                    root = root.left;
                }
                else
                {
                    if (treeStack.Count == 0) break;
                    root = treeStack.Pop();
                    root = root.right;
                }
            }
            return valList;
        }

        public IList<int> InorderTraversal(TreeNode root)
        {
            var orderList = new List<int>();
            var nodeStack = new Stack<TreeNode>();

            if (root == null) return orderList;

            while (true)
            {
                if (root != null)
                {
                    nodeStack.Push(root);
                    root = root.left;
                }
                else
                {
                    if (nodeStack.Count == 0) break;
                    root = nodeStack.Pop();
                    orderList.Add(root.val);
                    root = root.right;

                }
            }

            return orderList;


        }

        public IList<int> PostorderTraversal(TreeNode root)
        {
            //======================== Strategy =======================================//
            //Implementing an iterative approach to Post order traversal requires two helpers
            // you will need a current node pointer and a pointer to save the last popped element
            
            var orderList = new List<int>();
            var nodeStack = new Stack<TreeNode>();
            
            TreeNode lastPopped;
            
            // Ensuring that root is not null
            if (root == null) return orderList;

            var curr = root;

            //this loop will execute until curr is null && there is nothing in the stack
            while (curr != null || nodeStack.Count > 0)
            {
                // 1. Traverse the left side of the node first:
                        // - This means if the curr node is not null
                        // set curr to the left node
                if (curr != null)
                {
                    nodeStack.Push(curr);
                    curr = curr.left;
                }
                else
                {
                    //when curr is null, peek back at the stack. 
                    // You will be looking at the last know node to have a value, and you want to see if the right side has a value
                    // if so, set current to that node, you are essentially "skipping" over the head node 
                    if (nodeStack.Peek().right != null)
                    {
                        curr = nodeStack.Peek().right;
                    }
                    else
                    {
                        // if the node you peeked does not have right. Pop it,  save it, and then store(print/add to list) the value 
                        lastPopped = nodeStack.Pop();
                        orderList.Add(lastPopped.val);
                        
                        // Heres the tricky part if: if you were to stop a the line above you would end up in a forever loop
                        // so to avoid that, we make sure that the last value popped is not equal to the peek values right
                        // and if it is we go back to the stack and pop of the next node; 
                        //NOTE: the first condition is that we dont get a null reference error while accessing the right prop
                        //

                        while (nodeStack.Count > 0 && lastPopped == nodeStack.Peek().right)
                        {
                            lastPopped = nodeStack.Pop();
                            orderList.Add(lastPopped.val);
                        }
                    }

                }

            }

            return orderList;
        }
    }
}