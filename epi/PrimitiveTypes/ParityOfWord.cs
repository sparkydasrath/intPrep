namespace PrimitiveTypes
{
    public class ParityOfWord
    {
        /*
          pg 58
          5.1 COMPUTING THE PARITY OF A WORD
            The parity of a binary word is 1 if the number of Is in the word is odd; otherwise,
            it is 0. For example, the parity of 1011 is 1, and the parity of 10001000 is 0. Parity
            checks are used to detect single bit errors in data storage and communication. It is
            fairly straightforward to write code that computes the parity of a single 64-bit word.

            How would you compute the parity of a very large number of 64-bit words?
            Hint: Use a lookup table, but don't use 2^64 entries!
         */

        public short GetParity(long n)
        {
            // long numBits = 0;
            short results = 0;
            while (n != 0)
            {
                // numBits += (n & 1);
                results ^= (short)(n & 1);
                n >>= 1;
            }

            // int result = numBits % 2 == 0 ? 0 : 1;

            return results;
        }
    }
}