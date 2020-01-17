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

        public linkedList DeleteDuplicates(linkedList head)
        {
            //==============Strategy=======================//
            // this starategy works for a sorted list
            //1. starting at the head node, look at the next node's data value
            //2. if the current nodes data value and the next node's data value are equal 
            // then have the next pointer go to the "next next" node
            // Note: when you ddo this DO not move the pointer, there might be several duplicates
            //3. only if the data values of current and next node are differnt do you move current head forward  

            var currNode = head;

            while (currNode != null && currNode.next != null)
            {
                if (currNode.data == currNode.next.data)
                {
                    currNode.next = currNode.next.next;
                }
                else
                {
                    currNode = currNode.next;
                }

            }

            return head;

        }

        public linkedList ReverseList(linkedList head)
        {
            
            if (head == null) return null;

            var currNode = head;
            var saveNode = currNode.next;

            while (currNode.next != null)
            {
                currNode.next = currNode.next.next;
                saveNode.next = head;
                head = saveNode;
                saveNode = currNode.next;
            }

            return head;
        }

          public bool IsPalindrome(linkedList head) {
        var slow = head;
        var fast = head;
        var check = head;
        
        
        
        //null head is read as a palindrome
        //one item list are palindromes
        if(head == null || head.next == null) return true;
        
            
        // find the middle first: Employ the fast/slow method
        // where fast moves two nodes and slow moves one node
        // when fast == null or fast.next == null, we have hit the last node
        // and our slow node is on the middle node. 
        // Note: If the # of nodes is odd, slow will be sqaurely in the middle 
        //       If the # of nodes are even it will be at the middle node closer to the end
        while(fast!=null && fast.next!=null)
        {
            slow = slow.next;
            fast = fast.next.next;
            
        }
        
        //reverse the node from middle to end 
        //next heck if it was an even list or odd list 
        if(fast != null) //this is the odd condition
        {
            slow=slow.next;    
        }
        
        // reversing  function need a few more refernce objects
        var mid = slow;
        var track = slow.next;
        while(slow.next !=null)
        {
            slow.next=slow.next.next;
            track.next = mid;
            mid = track;
            track=slow.next;
           
        }
        
        // checking values for same data
        while(mid != null)
        {
            if(mid.data != check.data) return false;
            mid=mid.next;
            check = check.next;
        }
         
        return true;
        
    }
    }