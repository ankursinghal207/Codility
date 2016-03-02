using System.Collections;

namespace Codility
{
    class Lesson2_CyclicRotation
    {
        public static int[] Solution(int[] A, int N, int K)
        {
            /*Problem
               A zero-indexed array A consisting of N integers is given. Rotation of the array means that each element is shifted right by one index, and the last element of the array is also moved to the first place.

               For example, the rotation of array A = [3, 8, 9, 7, 6] is [6, 3, 8, 9, 7]. The goal is to rotate array A K times; that is, each element of A will be shifted to the right by K indexes.

               Write a function:

               public int[] solution(int[] A, int K);

               that, given a zero-indexed array A consisting of N integers and an integer K, returns the array A rotated K times.

               For example, given array A = [3, 8, 9, 7, 6] and K = 3, the function should return [9, 7, 6, 3, 8].

               Assume that:

               N and K are integers within the range [0..100];
               each element of array A is an integer within the range [−1,000..1,000].
               In your solution, focus on correctness. The performance of your solution will not be the focus of the assessment.
               */
            
            //Test data
            //A = new int[] { 3, 8 };
            //K = 1;

            // No rotation possible
            if (A.Length < 2 || K == 0)
                return A;

            Hashtable hshNewIndex = new Hashtable();

            int newIndex = 0;
            for (int index = 0; index < A.Length; index++)
            {

                if (index + K < A.Length)
                    newIndex = index + K;
                else
                    newIndex = (K + index) % A.Length;

                hshNewIndex[newIndex] = A[index];
            }
            foreach (int key in hshNewIndex.Keys)
            {
                A[key] = (int)hshNewIndex[key];
            }
            return A;

            /* Codility Score 100% */
        }
    }
}
