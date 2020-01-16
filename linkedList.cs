using System;

namespace interviewPractice
{
    public class linkedListDBL
    {
        int data { get; set; }
        public linkedListDBL prev { get; set; }
        public linkedListDBL next { get; set; }
        public linkedListDBL(int value)
        {
            data = value;
        }

        public linkedListDBL Insert(linkedListDBL head, int data)
        {
            linkedListDBL targetNode = new linkedListDBL(data);
            linkedListDBL currNode = head;
            if (head == null)
            {
                //if head hasnt been defined, then the target node becomes the                            //first node
                head = targetNode;
            }
            else if (data < head.data)
            {
                //scenario 2: 
                targetNode.next = currNode;
                head = targetNode;
            }
            else
            {
                while (currNode.next != null && (currNode.next.data < targetNode.data))
                {
                    currNode = currNode.next;
                }
                targetNode.next = currNode.next;
                currNode.next = targetNode;
            }
            return head;
        }

        public linkedListDBL Reverse(linkedListDBL head)
        {
            linkedListDBL currNode = head;

            while (currNode != null)
            {
                linkedListDBL saveNode = currNode.prev;
                currNode.prev = currNode.next;
                currNode.next = saveNode;
                head = currNode;
                currNode = currNode.prev;
            }

            return head;
        }

    }

    public class linkedList
    {
        int data { get; set; }
        public linkedList next { get; set; }
        public linkedList(int value)
        {
            data = value;
        }

        public linkedList RotateRight(linkedList head, int k)
        {
            if (head == null) { return head; }

            var tailNode = head;

            int rotations = 0;
            int position = 0;
            int size = 1;

            //This loop is to determine how many nodes are in the lis
            while (tailNode.next != null)
            {
                tailNode = tailNode.next;
                size++;
            }

            //this assignment is to dertimine the number of relative rotations
            rotations = k % size;

            //we create a circle by connetcting the the original tail to the head
            tailNode.next = head;

            //from here we cycle through to our new tail
            while (position < (size - rotations))
            {
                tailNode = tailNode.next;
                position++;
            }

            //Once in position we reset the Head and break the loop
            head = tailNode.next;
            tailNode.next = null;

            // Once the loop is broken return the head
            return head;
        }
    }
}