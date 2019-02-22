using System.Collections.Generic;

namespace Strings
{
    public class FlipGame
    {
        /*
         293. Flip Game https://leetcode.com/problems/flip-game/
        Easy

        You are playing the following Flip Game with your friend: Given a string that contains only these two characters: + and -, you and your friend take turns to flip two consecutive "++" into "--". The game ends when a person can no longer make a move and therefore the other person will be the winner.

        Write a function to compute all possible states of the string after one valid move.

        Example:

        Input: s = "++++"
        Output:
        [
          "--++",
          "+--+",
          "++--"
        ]
         */

        public List<string> GeneratePossibleNextMoves(string s)
        {
            List<string> result = new List<string>();
            for (int head = 1; head < s.Length; head++)
            {
                int tail = head - 1;

                if (s[head] == '+' && s[tail] == '+')
                {
                    char[] temp = s.ToCharArray();
                    temp[head] = '-';
                    temp[tail] = '-';
                    result.Add(new string(temp));
                }
            }

            return result;
        }
    }
}