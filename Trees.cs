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

        public IList<IList<int>> LevelOrder(TreeNode root)
        {

            IList<IList<int>> levels = new List<IList<int>>();
            var nodeQ = new Queue<TreeNode>();

            if (root == null) return levels;

            //If the root given is not null add it to the queue
            var curr = root;
            nodeQ.Enqueue(curr);

            //the next time we get an empty queue should be when we are done travering levels
            while (nodeQ.Count > 0)
            {
                IList<int> level = new List<int>();

                // the number of items in the queue at this time represent the number of row items
                int spaces = nodeQ.Count;

                // create a looop that will run through the number of items in the row 
                for (int i = 0; i < spaces; i++)
                {
                    //this is optional but makes more sense to me, create a variable to hold the 
                    // item at the top of the stack                           
                    TreeNode peeker = nodeQ.Peek();

                    //if there is a left child add it to the queue
                    if (peeker.left != null)
                    {
                        nodeQ.Enqueue(peeker.left);
                    }

                    //if there is a right child add it to the queue
                    if (peeker.right != null)
                    {
                        nodeQ.Enqueue(peeker.right);
                    }

                    // pop the node off the stack and print/add the value to the stack 
                    level.Add(nodeQ.Dequeue().val);
                }
                //add the values just captured to the super list             
                levels.Add(level);
            }


            return levels;
        }

        public bool IsSymmetric(TreeNode root)
        {   //============================Strategy ======================================//
            //THE key to solving this one is to know that youy need another function 
            // that takes in two nodes and compares the trees and values
            // In the original function you just want to make sure the root isnt null 
            // if the root is null return true, but if this was an interview Id get clarification first
            // Also a tree with no left and right is symetrical so we dont even look at that

            if (root == null) return true;

            // pass in the left and right sub trees to the custom function
            // the funtion will be recursive so return it;

            return isMirrored(root.left, root.right);
        }

        public bool isMirrored(TreeNode right, TreeNode left)
        {
            //if we have reached a leaf ensure that the other side has reached has also reached a leaf
            if (left == null || right == null)
            {
                return left == right;
            }

            //lets check the values of each node 
            if (left.val != right.val) return false;

            // this recursion table gets crazy but all you need to remember is 
            // the outside have to match && and the insides have to match
            return isMirrored(left.left, right.right) && isMirrored(left.right, right.left);
        }

        public bool HasPathSum(TreeNode root, int sum)
        {

            if (root == null)
            {
                return false;
            }
            // this condition is for if we have hit a leaf node  with no children and is the sum;
            else if (root.left == null && root.right == null && (sum - root.val) == 0)
            {
                return true;
            }
            else
            {
                return HasPathSum(root.left, sum - root.val) || HasPathSum(root.right, sum - root.val);
            }

        }

        public TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return null;
            }

            return ConstructBST(nums, 0, nums.Length - 1);

        }
        // on this recursive problem we want to:
        // 1. Find the middle
        // 2. make that middle value the current, "root", node
        // 3. recurse to find left node
        // 4. recurse to find right node 
        // 5. return the current
        private TreeNode ConstructBST(int[] arr, int startPosition, int endPosition)
        {
            if (startPosition > endPosition) { return null; }

            int middle = startPosition + (endPosition - startPosition) / 2;
            var current = new TreeNode(arr[middle]);
            current.left = ConstructBST(arr, startPosition, middle - 1);
            current.right = ConstructBST(arr, middle + 1, endPosition);
            return current;


        }
    }
}