using System;
using System.Collections.Generic;
using System.Linq;

namespace interviewPractice
{
    public class HashMaps
    {
      public int SingleNumber(int[] nums) {
       var frequency = new Dictionary<int, int>();
        
       var test =  nums.GroupBy(a => a).Where(a => a.Count() ==1);

        foreach(int number in nums){
            
            if(frequency.ContainsKey(number))
            {
                frequency[number]++;
            }else{
                frequency.Add(number,1);
            }
        }
        
        
        System.Console.WriteLine("stopping point");

        return 5;
    }  
    }
}