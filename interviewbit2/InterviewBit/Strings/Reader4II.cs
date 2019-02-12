namespace Strings
{
    // ReSharper disable once InconsistentNaming
    public class Reader4II : Reader4
    {
        /*
         *158. Read N Characters Given Read4 II - Call multiple times https://leetcode.com/problems/read-n-characters-given-read4-ii-call-multiple-times/
            Hard

            Given a file and assume that you can only read the file using a given method read4, implement a method read to read n characters. Your method read may be called multiple times.

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

            File file("abc");
            Solution sol;
            // Assume buf is allocated and guaranteed to have enough space for storing all characters
            // from the file.
            sol.read(buf, 1); // After calling your read method, buf should contain "a". We read a total of 1 character from the file, so return 1.
            sol.read(buf, 2); // Now buf should contain "bc". We read a total of 2 characters from the file, so return 2.
            sol.read(buf, 1); // We have reached the end of file, no more characters can be read. So return 0.

            Example 2:

            File file("abc");
            Solution sol;
            sol.read(buf, 4); // After calling your read method, buf should contain "abc". We read a total of 3 characters from the file, so return 3.
            sol.read(buf, 1); // We have reached the end of file, no more characters can be read. So return 0.

            Note:

                Consider that you cannot manipulate the file directly, the file is only accesible for read4 but not for read.
                The read function may be called multiple times.
                Please remember to RESET your class variables declared in Solution, as static/class variables are persisted across multiple test cases. Please see here for more details.
                You may assume the destination buffer array, buf, is guaranteed to have enough space for storing n characters.
                It is guaranteed that in a given test case the same buffer buf is called by read.

         *
         */

        /* A temp buffer keep the the API call result,
            As we call get values in chunks of 4, sometimes we need to keep the 'left over' from previous read
        */
        private readonly char[] bufForRead4 = new char[4];

        // To record the pointer of the buffer
        private int bufPointer = 0;

        // Amount left to be copied from buffer to char[] buff.
        private int countFromRead4 = 0;

        public int Read(char[] buf, int n)
        {
            // https://leetcode.com/problems/read-n-characters-given-read4-ii-call-multiple-times/discuss/219675/C-Solution-with-commented-code.-O(N)-time-complexity-constant-space
            int totalSoFar = 0;

            while (totalSoFar < n)
            {
                if (bufPointer == 0) // if buf Pointer is at the beginning then it's a good time to call API
                {
                    countFromRead4 = Read4(bufForRead4); // Read the actual file and keep that info in buffer,
                    // buffCount is how many 'good' chars in buffer to be consumed
                }

                if (countFromRead4 == 0) break;  // No more to read from the file via the Read4 API

                while (totalSoFar < n && bufPointer < countFromRead4) // Record the info from our local "buffer" to "buf"
                {
                    // Copy values from the file to char[] buff, that has been already recorded in
                    // char[] buffer
                    buf[totalSoFar] = bufForRead4[bufPointer];
                    totalSoFar++;
                    bufPointer++;
                }

                if (bufPointer >= countFromRead4)  // Time to read more from file via the API
                {
                    bufPointer = 0;   // this will trigger line "if (bufferPointer == 0)" then we will read from file
                }
            }

            return totalSoFar;   // this will return the actual number of chars to be read from the char[] buff
        }

        public int ReadMyAttempt(char[] buf, int n)
        {
            // when we call Read(buf, n) ==> need to call rad4(buff, n) and get the total if n < 4,
            // we can call read4 and fill the total buff and only remove the bits we care about if n
            // > 4, need to make several calls to read4 to get enough chars to fulfill this request

            int total = 0;
            char[] temp = new char[4];

            while (true)
            {
                if (n < 4)
                {
                    if (total < n)
                    {
                        // need to fill the buffer at least once

                        int count = Read4(temp); // reads 4 chars from

                        for (int i = 0; i < count; i++)
                        {
                            buf[total] = temp[i];
                            total++;
                        }

                        RemoveCharsFromBufAndUpdateDecrementTotalCount();
                        return UpdatedTotalCount();
                    }

                    RemoveCharsFromBufAndUpdateDecrementTotalCount();
                    return UpdatedTotalCount();
                }
                else
                {
                    if (total > n)
                    {
                        RemoveCharsFromBufAndUpdateDecrementTotalCount();
                        return UpdatedTotalCount();
                    }
                    else
                    {
                        // need to figure out how many more times we have to call read4 to get the
                        // right chars
                        int numOfCalls = ((n - total) / 4) + ((n - total) % 4);

                        for (int i = 0; i < numOfCalls; i++)
                        {
                            int internalCount = Read4(temp);

                            for (int j = 0; j < internalCount; j++)
                            {
                                buf[total] = temp[j];
                                total++;
                            }

                            if (internalCount == 0)
                            {
                                break;
                            }
                        }

                        RemoveCharsFromBufAndUpdateDecrementTotalCount();
                        return UpdatedTotalCount();
                    }
                }
            }
        }

        private void RemoveCharsFromBufAndUpdateDecrementTotalCount() => throw new System.NotImplementedException();

        private int UpdatedTotalCount() => throw new System.NotImplementedException();
    }
}