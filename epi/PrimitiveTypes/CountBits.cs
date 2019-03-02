namespace PrimitiveTypes
{
    public class CountBits
    {
        /*
         pg 57
         Writing a program to count the number of bits that are set to 1 in an integer is a good way to get up to speed with primitive types.
         */

        public int GetBitCount(int n)
        {
            int numBits = 0;
            while (n != 0)
            {
                numBits += (n & 1);
                n >>= 1;
            }
            return numBits;
        }
    }
}