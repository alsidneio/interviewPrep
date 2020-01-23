using System;

namespace interviewPractice
{
    public class Math
    {
        public int CountPrimes(int n)
        {
            var primes = new bool[n];
            var primeCount = 0;

            // to help cut down on the number of computations
            // we use the fact the largest factor needed to determine the rest of the factors
            //is the integer of sqrt(n). so our upper limit is i-squared
            for (int i = 2; i * i < n; i++)
            {
                if (!primes[i])
                {
                    //Cycle through all the factors of i
                    for (int j = i; i * j < n; j++)
                    {
                        primes[j * i] = true;
                    }
                }
            }

            for (int i = 2; i < n; i++)
            {
                if (!primes[i]) primeCount++;
            }

            return primeCount;
        }

    }
}

