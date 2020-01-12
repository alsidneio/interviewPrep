using System;
using System.Linq;
using System.Collections.Generic;

namespace interviewPractice
{
    public class Dictionaries
    {
       public static void Convert()
       {
        var map = new Dictionary<string,int>();
        string[] words = new string[]{"hey", "ho", "lets", "go","hey","roxane"};
        string[] note = new string[]{"hey", "lets", "go","roxane"};
        foreach(var item in words){
            if(map.ContainsKey(item)){
                map[item]++;
            }else{
                map.Add(item,1);
            }
        }
        foreach (var item in map)
        {
           Console.WriteLine(note.Count(a => a==item.Key));
        }
        System.Console.WriteLine("stopping point");
       }
      
    }
}