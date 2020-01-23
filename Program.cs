using System;

namespace interviewPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var maps = new HashMaps();
            maps.SingleNumber(new int[] { 2, 2, 1 });

            IsHappy(19);


        }

        static bool IsHappy(int n)
        {
            int answer = 0;


            while (answer != 1)
            {
                answer = 0;
                string digits = n.ToString();
                foreach (var digit in digits)
                {
                    answer += (int)Math.Pow(char.GetNumericValue(digit), 2);
                }
                n = answer;

            }

            return true;

        }
    }
}
