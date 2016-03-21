using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessons
{
    class Lesson5_CountDiv
    {
        /* Problem
        Write a function:

        class Solution { public int solution(int A, int B, int K); }

        that, given three integers A, B and K, returns the number of integers within the range [A..B] that are divisible by K, i.e.:

        { i : A ≤ i ≤ B, i mod K = 0 }

        For example, for A = 6, B = 11 and K = 2, your function should return 3, because there are three numbers divisible by 2 within the range [6..11], namely 6, 8 and 10.

        Assume that:

        A and B are integers within the range [0..2,000,000,000];
        K is an integer within the range [1..2,000,000,000];
        A ≤ B.
        Complexity:

        expected worst-case time complexity is O(1);
        expected worst-case space complexity is O(1).
        */
        public static int Solution(int A, int B, int K)
        {
            A = 3;
            B = 6;
            K = 2;
            int NumberOfDivisors = 0;

            // B is the only divisor
            if (B == 0)
                return 1;

            // If out of range
            if (K > B)
                return 0;

            if (A % K == 0 )
                NumberOfDivisors++;

            NumberOfDivisors+= B / K - A / K;

            return NumberOfDivisors;

            /* Codility Score 100% 
            https://codility.com/demo/results/trainingB2YNMW-53U/
            */
        }
    }
}
