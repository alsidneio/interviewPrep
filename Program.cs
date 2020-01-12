using System;

namespace interviewPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var head = new linkedListDBL(1);
            head.Insert(head,2);
            head.Insert(head,3);
            head.Insert(head,4);
            head.Insert(head,5);
            

            var result = head.Reverse(head);
            
            Dictionaries.Convert();
        }
    }
}
