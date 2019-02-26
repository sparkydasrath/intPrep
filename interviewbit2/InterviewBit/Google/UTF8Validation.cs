using System;

namespace Google
{
    public class Utf8Validation
    {
        /*
         393. UTF-8 Validation https://leetcode.com/problems/utf-8-validation/
        Medium

        A character in UTF8 can be from 1 to 4 bytes long, subjected to the following rules:

            For 1-byte character, the first bit is a 0, followed by its unicode code.
            For n-bytes character, the first n-bits are all one's, the n+1 bit is 0, followed by n-1 bytes with most significant 2 bits being 10.

        This is how the UTF-8 encoding would work:

           Char. number range  |        UTF-8 octet sequence
              (hexadecimal)    |              (binary)
           --------------------+---------------------------------------------
           0000 0000-0000 007F | 0xxxxxxx
           0000 0080-0000 07FF | 110xxxxx 10xxxxxx
           0000 0800-0000 FFFF | 1110xxxx 10xxxxxx 10xxxxxx
           0001 0000-0010 FFFF | 11110xxx 10xxxxxx 10xxxxxx 10xxxxxx

        Given an array of integers representing the data, return whether it is a valid utf-8 encoding.

        Note:
        The input is an array of integers. Only the least significant 8 bits of each integer is used to store the data. This means each integer represents only 1 byte of data.

        Example 1:

        data = [197, 130, 1], which represents the octet sequence: 11000101 10000010 00000001.

        Return true.
        It is a valid utf-8 encoding for a 2-bytes character followed by a 1-byte character.

        Example 2:

        data = [235, 140, 4], which represented the octet sequence: 11101011 10001100 00000100.

        Return false.
        The first 3 bits are all one's and the 4th bit is 0 means it is a 3-bytes character.
        The next byte is a continuation byte which starts with 10 and that's correct.
        But the second continuation byte does not start with 10, so it is invalid.

        LC description solution: https://leetcode.com/articles/utf-8-validation/#

         */

        public bool ValidUtf8(int[] data)
        {
            int bytesToProcess = 0;

            for (int i = 0; i < data.Length; i++)
            {
                /*
                 Convert the number to binary string
                 If the binary string length > 8, need to take only the 8 bit LSB
                 If it is smaller, we need to pad it from the right with 0s
                 */
                string numAsBinaryString = Convert.ToString(data[i], 2); // convert to base 2
                if (numAsBinaryString.Length >= 8)
                {
                    // strip out MSB parts. Broke into two parts to help visualize
                    string temp = numAsBinaryString.Substring(numAsBinaryString.Length - 8);
                    numAsBinaryString = temp;
                }
                else
                {
                    // pad with zeros
                    string temp = "00000000".Substring(numAsBinaryString.Length % 8) + numAsBinaryString;
                    numAsBinaryString = temp;
                }

                if (bytesToProcess == 0)
                {
                    // start of the processing

                    /* get the number of bytes to process
                       NOTE: at this point we are only looking at the first item in the original
                       data array, and that will tell us how many bytes we should be getting
                 */

                    for (int j = 0; j < numAsBinaryString.Length; j++)
                    {
                        if (numAsBinaryString[j] == '0') break;
                        bytesToProcess++;
                    }

                    // at this point we know how many bytes we have to process
                    if (bytesToProcess == 0)
                    {
                        // this means there are no grouping of bytes - everything is a single byte
                        continue;
                    }

                    // Invalid scenarios according to the rules of the problem.
                    if (bytesToProcess > 4 || bytesToProcess == 1) return false;
                }
                else
                {
                    // Else, we are processing integers which represent bytes which are a part of a
                    // UTF-8 character. So, they must adhere to the pattern `10xxxxxx`.
                    if (!(numAsBinaryString[0] == '1' && numAsBinaryString[1] == '0')) return false;
                }

                // We reduce the number of bytes to process by 1 after each integer.
                bytesToProcess--;
            }

            // This is for the case where we might not have the complete data for a particular UTF-8 character.
            return bytesToProcess == 0;
        }
    }
}