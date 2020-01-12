using System;

namespace interviewPractice
{
    public class linkedListDBL
    {
        int data {get; set;}
        public linkedListDBL prev {get;set;}
        public linkedListDBL next{get; set;}
        public linkedListDBL(int value){
            data =value;
        }

        public linkedListDBL Insert(linkedListDBL head, int data){
            linkedListDBL targetNode = new linkedListDBL(data);
            linkedListDBL currNode = head;
            if(head == null){ 
                //if head hasnt been defined, then the target node becomes the                            //first node
                head = targetNode;
            }else if(data<head.data){
                //scenario 2: 
                targetNode.next = currNode;
                head = targetNode;
            }else{
                while(currNode.next != null && (currNode.next.data<targetNode.data)){
                    currNode = currNode.next;
                }
                targetNode.next=currNode.next;
                currNode.next=targetNode;
            }
            return head;
        }

        public linkedListDBL Reverse(linkedListDBL head){
            linkedListDBL currNode = head;
            linkedListDBL saveNode=currNode;
            if(head == null){ 
                
            }else{
                while(saveNode != null ){
                    saveNode = currNode.next;
                    saveNode.prev=null;
                    currNode=currNode.next;
                    currNode.next=null;
                    head = currNode.prev;
                   
                    currNode =saveNode;
                    saveNode =saveNode.next;
                    System.Console.WriteLine("stopping point");
                }
                
            }
            return head;
        }

    }
}