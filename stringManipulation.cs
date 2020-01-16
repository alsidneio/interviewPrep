using System;
using System.Collections.Generic;
using System.Linq;

namespace interviewPractice
{
    public class StringManipulation
    {
        public int makeAnagram(string a, string b) 
        {
            int deletions = 0;
            var letterMap = new Dictionary<char,int>();
            foreach(var letter in a ){
                if(letterMap.ContainsKey(letter)){
                    letterMap[letter]++;
                }else{
                    letterMap.Add(letter,1);
                }   
            }
            foreach(var letter in b ){
                if(letterMap.ContainsKey(letter)){
                    letterMap[letter]--;
                }else{
                    letterMap.Add(letter,-1);
                }  
            }
            foreach(var item in letterMap){
                if(item.Value!=0) deletions+=Math.Abs(item.Value);
            }
            
            return deletions;
        }

        public string isValid(string input){
            string valid="";
            var letterMap = new Dictionary<char, int>();
            foreach(char letter in input)
            {
                if(letterMap.ContainsKey(letter))
                {
                    letterMap[letter]++;
                }else{
                    letterMap.Add(letter,1);
                }
            }
            //Test case 1: Frequency for each letter is the same 
            if(letterMap.Values.Distinct().Count()==1){valid="YES";}

            //Test Case 2: Frequency of one character varies by 1
            if(letterMap.Values.Distinct().Count() ==2)
            {
                var DistinctList = letterMap.Values.Distinct().ToList();
                if((Math.Abs(DistinctList[0]-DistinctList[1]))==1){
                    valid ="YES";
                }
            }else{valid = "NO";}
            
            return valid;
        }
    }
}