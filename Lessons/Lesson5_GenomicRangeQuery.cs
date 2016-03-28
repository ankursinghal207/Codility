using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.Lessons
{
    class Lesson5_GenomicRangeQuery
    {
        public static int[] Solution2(string S, int[] P, int[] Q)
        {

            // Test Data
            S = "CAGCCTA";
            P = new int[] { 2, 5, 0 };
            Q = new int[] { 4, 5, 6 };
            //A, C, G and T have impact factors of 1, 2, 3 and 4

            int[] ImpactFactor = new int[P.Length];
            int MinFactor = 999;
            for (int index = 0; index < P.Length; index++)
            {
                //if(P[index]>=Q[index])
                string substring = S.Substring(P[index], Q[index] - P[index] + 1);

                if (substring.Contains("A"))
                    MinFactor = 1;
                else if (substring.Contains("C"))
                    MinFactor = 2;
                else if (substring.Contains("G"))
                    MinFactor = 3;
                else if (substring.Contains("T"))
                    MinFactor = 4;

                ImpactFactor[index] = MinFactor;
            }
            return ImpactFactor;
        }

        public static int[] Solution(string S, int[] P, int[] Q)
        {
            /* Problem 
            A DNA sequence can be represented as a string consisting of the letters A, C, G and T, which correspond to the types of successive nucleotides in the sequence. Each nucleotide has an impact factor, which is an integer. Nucleotides of types A, C, G and T have impact factors of 1, 2, 3 and 4, respectively. You are going to answer several queries of the form: What is the minimal impact factor of nucleotides contained in a particular part of the given DNA sequence?

            The DNA sequence is given as a non-empty string S = S[0]S[1]...S[N-1] consisting of N characters. There are M queries, which are given in non-empty arrays P and Q, each consisting of M integers. The K-th query (0 ≤ K < M) requires you to find the minimal impact factor of nucleotides contained in the DNA sequence between positions P[K] and Q[K] (inclusive).

            For example, consider string S = CAGCCTA and arrays P, Q such that:

            P[0] = 2    Q[0] = 4
            P[1] = 5    Q[1] = 5
            P[2] = 0    Q[2] = 6
            The answers to these M = 3 queries are as follows:

            The part of the DNA between positions 2 and 4 contains nucleotides G and C (twice), whose impact factors are 3 and 2 respectively, so the answer is 2.
            The part between positions 5 and 5 contains a single nucleotide T, whose impact factor is 4, so the answer is 4.
            The part between positions 0 and 6 (the whole string) contains all nucleotides, in particular nucleotide A whose impact factor is 1, so the answer is 1.
            Write a function:

            class Solution { public int[] solution(string S, int[] P, int[] Q); }

            that, given a non-empty zero-indexed string S consisting of N characters and two non-empty zero-indexed arrays P and Q consisting of M integers, returns an array consisting of M integers specifying the consecutive answers to all queries.

            The sequence should be returned as:

            a Results structure (in C), or
            a vector of integers (in C++), or
            a Results record (in Pascal), or
            an array of integers (in any other programming language).
            For example, given the string S = CAGCCTA and arrays P, Q such that:

            P[0] = 2    Q[0] = 4
            P[1] = 5    Q[1] = 5
            P[2] = 0    Q[2] = 6
            the function should return the values [2, 4, 1], as explained above.

            Assume that:

            N is an integer within the range [1..100,000];
            M is an integer within the range [1..50,000];
            each element of arrays P, Q is an integer within the range [0..N − 1];
            P[K] ≤ Q[K], where 0 ≤ K < M;
            string S consists only of upper-case English letters A, C, G, T.
            Complexity:

            expected worst-case time complexity is O(N+M);
            expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).
            Elements of input arrays can be modified.
            */

            // Test Data
            S = "CAGCCTA";
            P = new int[] { 2, 5, 0 };
            Q = new int[] { 4, 5, 6 };
            //A, C, G and T have impact factors of 1, 2, 3 and 4

            // 2D array to store count of occurance of A, C and G at each index (using prefix sum method).
            // Initially value at each index of 2D array is 0,0
            int[,] PrefixSums = new int[3, S.Length + 1];

            // Get the character array of input string
            char[] inputString = S.ToCharArray();

            // loop through the input string 
            for (int index = 0; index < S.Length; index++)
            {
                short a = 0, c = 0, g = 0;
                if (inputString[index].ToString() == "A")
                    a = 1;
                else if (inputString[index].ToString() == "C")
                    c = 1;
                else if (inputString[index].ToString() == "G")
                    g = 1;

                // Use prefix sum methods to store the count of occurance of each charachter in the input string.
                PrefixSums[0, index + 1] = PrefixSums[0, index] + a;
                PrefixSums[1, index + 1] = PrefixSums[1, index] + c;
                PrefixSums[2, index + 1] = PrefixSums[2, index] + g;
            }

            int[] ImpactFactor = new int[P.Length];

            for (int index = 0; index < P.Length; index++)
            {
                int startIndex = P[index];
                // Add 1 to end index as zeroth element in PrefixSums array was initialize as zero (That is follwing value are zero by default (0,0), (1,0) and (2,0))
                int endIndex = Q[index] + 1;

                // Check if there was any occurance of "A"
                if ((PrefixSums[0, endIndex] - PrefixSums[0, startIndex]) > 0)
                    ImpactFactor[index] = 1;
                // Check if there was any occurance of "C"
                else if ((PrefixSums[1, endIndex] - PrefixSums[1, startIndex]) > 0)
                    ImpactFactor[index] = 2;
                // Check if there was any occurance of "G"
                else if ((PrefixSums[2, endIndex] - PrefixSums[2, startIndex]) > 0)
                    ImpactFactor[index] = 3;
                // Check if there was any occurance of "T"
                else
                    ImpactFactor[index] = 4;
            }
            return ImpactFactor;

             /* Codility Score 100%             
             https://codility.com/demo/results/trainingJ6ZCQY-336/
             */
        }

    }
}
