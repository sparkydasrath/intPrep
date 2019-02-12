using System;

namespace Strings
{
    public class Reader4I : Reader4
    {
        // inherit to get access to Read4 to mimic the LC code

        /*
         *  THIS PROBLEM WAS HARD AS FUCK TO UNDERSTAND
         *
         *  157. Read N Characters Given Read4 https://leetcode.com/problems/read-n-characters-given-read4/
        Easy

        Given a file and assume that you can only read the file using a given method read4, implement a method to read n characters.

        Method read4:

        The API read4 reads 4 consecutive characters from the file, then writes those characters into the buffer array buf.

        The return value is the number of actual characters read.

        Note that read4() has its own file pointer, much like FILE *fp in C.

        Definition of read4:

            Parameter:  char[] buf
            Returns:    int

        Note: buf[] is destination not source, the results from read4 will be copied to buf[]

        Below is a high level example of how read4 works:

        File file("abcdefghijk"); // File is "abcdefghijk", initially file pointer (fp) points to 'a'
        char[] buf = new char[4]; // Create buffer with enough space to store characters
        read4(buf); // read4 returns 4. Now buf = "abcd", fp points to 'e'
        read4(buf); // read4 returns 4. Now buf = "efgh", fp points to 'i'
        read4(buf); // read4 returns 3. Now buf = "ijk", fp points to end of file

        Method read:

        By using the read4 method, implement the method read that reads n characters from the file and store it in the buffer array buf. Consider that you cannot manipulate the file directly.

        The return value is the number of actual characters read.

        Definition of read:

            Parameters:	char[] buf, int n
            Returns:	int

        Note: buf[] is destination not source, you will need to write the results to buf[]

        Example 1:

        Input: file = "abc", n = 4
        Output: 3
        Explanation: After calling your read method, buf should contain "abc". We read a total of 3 characters from the file, so return 3. Note that "abc" is the file's content, not buf. buf is the destination buffer that you will have to write the results to.

        Example 2:

        Input: file = "abcde", n = 5
        Output: 5
        Explanation: After calling your read method, buf should contain "abcde". We read a total of 5 characters from the file, so return 5.

        Example 3:

        Input: file = "abcdABCD1234", n = 12
        Output: 12
        Explanation: After calling your read method, buf should contain "abcdABCD1234". We read a total of 12 characters from the file, so return 12.

        Example 4:

        Input: file = "leetcode", n = 5
        Output: 5
        Explanation: After calling your read method, buf should contain "leetc". We read a total of 5 characters from the file, so return 5.

        Note:

            Consider that you cannot manipulate the file directly, the file is only accesible for read4 but not for read.
            The read function will only be called once for each test case.
            You may assume the destination buffer array, buf, is guaranteed to have enough space for storing n characters.

         *
         * Best explanations
         * https://leetcode.com/problems/read-n-characters-given-read4/discuss/49496/Another-accepted-Java-solution
         *
         */

        /**
         * @param buf Destination buffer
         * @param n   Number of characters to read
         * @return    The number of actual characters read
         */

        public int Readv1(char[] buf, int n)
        {
            int totalSoFar = 0;
            char[] bufForRead4 = new char[4];

            while (true)
            {
                int countFromRead4 = Read4(bufForRead4);
                // the count could be 4 or less, either way just iterate it, store each char & update total

                for (int i = 0; i < countFromRead4; i++)
                {
                    if (totalSoFar == n) return totalSoFar; // met the threshold so return

                    // copy the results of Read4 to the 'output' buffer
                    buf[totalSoFar] = bufForRead4[i];
                    totalSoFar++;
                }

                if (countFromRead4 < 4) return totalSoFar;
            }
        }

        public int Readv2(char[] buf, int n)
        {
            /*
            Understand how read4() works, Initially, I thought it takes input buf as the parameter.
            But actually, *buf is just as the name refers, it's a buffer char array of size 4.

            Realize the corner case where buf = "abcdef", n = 5.
            The last iteration within the while loop gets count = 2, while we only need 1 last character. This is why we need to compare "count" with "n - total".

            If the length of buf can be divided by 4, then we need this check if (count == 0) break;
            to terminate the loop
             */
            char[] temp = new char[4];
            int total = 0;
            while (total < n)
            {
                int count = Read4(temp);
                /*
                 * doing the Min to figure out how many chars you need to copy over
                 * ex: n = 5, fileSize = 20 chars
                 *  read 4 in the first pass, then update total to 4
                 *  read 4 in the second pass and see that min(4, 5-4) = min(4, 1) => 1
                 *      which means we just need one more char from the results of read4
                 *      even though it has 4
                 */
                count = Math.Min(count, n - total);
                if (count == 0) break; // end of file, nothing more to be read and can't do anything else
                for (int i = 0; i < count; i++)
                {
                    buf[total++] = temp[i];
                }
            }
            return total;
        }
    }
}