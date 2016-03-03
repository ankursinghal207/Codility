using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessons
{
    class Lesson4_MissingInteger
    {

        public static int Solution(int[] A)
        {
            /* Problem
                Write a function:

                class Solution { public int solution(int[] A); }

                that, given a non-empty zero-indexed array A of N integers, returns the minimal positive integer (greater than 0) that does not occur in A.

                For example, given:

                A[0] = 1
                A[1] = 3
                A[2] = 6
                A[3] = 4
                A[4] = 1
                A[5] = 2
                the function should return 5.

                Assume that:

                N is an integer within the range [1..100,000];
                each element of array A is an integer within the range [−2,147,483,648..2,147,483,647].
                Complexity:

                expected worst-case time complexity is O(N);
                expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).
                Elements of input arrays can be modified
            */

            int missingInt = 0;
            
            // Create a new array
            int[] B = new int[A.Length+1];
            int countElements = 0;
            
            for (int index = 0; index < A.Length; index++ )
            {
                // Ignore all values smaller then 0 or greater then the length of input array 
                if (A[index] <= 0 || A[index] > A.Length)
                    continue;
                
                // Check if value is already added to array B
                if(B[A[index]] == 0)
                {
                    B[A[index]] = A[index];
                    countElements++;
                }
            }

            // if number of unique elements are equal to the length of array
            if (countElements != A.Length)
            {
                for (int index = 1; index < B.Length; index++)
                {
                    if (B[index] == 0)
                    {
                        missingInt = index;
                        break;
                    }
                }
            }
            // If nothing is missing, return the next number
            if (missingInt == 0)
                missingInt = countElements + 1;

            return missingInt;

            /* Codility Score 100% */

        }
    }
}
