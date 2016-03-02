using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility
{
    class Lesson4_PermCheck
    {
        public static int Solution(int[] A)
        {
            /* Problem
                A non-empty zero-indexed array A consisting of N integers is given.

                A permutation is a sequence containing each element from 1 to N once, and only once.

                For example, array A such that:

                A[0] = 4
                A[1] = 1
                A[2] = 3
                A[3] = 2
                is a permutation, but array A such that:

                A[0] = 4
                A[1] = 1
                A[2] = 3
                is not a permutation, because value 2 is missing.

                The goal is to check whether array A is a permutation.

                Write a function:

                class Solution { public int solution(int[] A); }

                that, given a zero-indexed array A, returns 1 if array A is a permutation and 0 if it is not.

                For example, given array A such that:

                A[0] = 4
                A[1] = 1
                A[2] = 3
                A[3] = 2
                the function should return 1.

                Given array A such that:

                A[0] = 4
                A[1] = 1
                A[2] = 3
                the function should return 0.

                Assume that:

                N is an integer within the range [1..100,000];
                each element of array A is an integer within the range [1..1,000,000,000].
                Complexity:

                expected worst-case time complexity is O(N);
                expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).
                Elements of input arrays can be modified.
            */

            // Test Data
            //A = new int[] { 4, 1, 3, 2 };

            if (A.Length == 0)
                return 0;

            // Create another array of length = length or array A + 1 element
            int[] B = new int[A.Length + 1];

            int indexB;

            for (int index = 0; index < A.Length; index++)
            {
                indexB = A[index];

                // if value of index is greater then the length of array, no point of continuing
                if (indexB > A.Length)
                    return 0;

                // check if duplicate records in array.
                if (B[indexB] == 0)
                    B[indexB] = index + 1;
                else // duplicate value
                    return 0;
            }

            // Check array B for premutations
            for (int i = 1; i < B.Length; i++)
            {
                if (B[i] == 0)
                    return 0;
            }
            return 1;

            /* Codility Score 100% */
        }
    }
}
