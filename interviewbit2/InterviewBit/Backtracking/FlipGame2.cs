using System.Collections.Generic;

namespace Backtracking
{
    public class FlipGame2
    {
        /*
         294. Flip Game II https://leetcode.com/problems/flip-game-ii/
        Medium

        You are playing the following Flip Game with your friend: Given a string that contains only these two characters: + and -, you and your friend take turns to flip two consecutive "++" into "--". The game ends when a person can no longer make a move and therefore the other person will be the winner.

        Write a function to determine if the starting player can guarantee a win.

        Example:

        Input: s = "++++"
        Output: true
        Explanation: The starting player can guarantee a win by flipping the middle "++" to become "+--+".
            }
            lifted from: https://leetcode.com/problems/flip-game-ii/discuss/73962/Share-my-Java-backtracking-solution

         */

        public bool CanWin(string s)
        {
            if (s == null || s.Length < 2)
            {
                return false;
            }

            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s.StartsWith("++"))
                {
                    string t = s.Substring(0, i) + "--" + s.Substring(i + 2);

                    if (!CanWin(t))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool CanWinUsingFlipGame1(string s)
        {
            // NOTE: This version passed LC

            if (s == null || s.Length < 2) return false;
            /*
            use the FlipGame.GeneratePossibleNextMoves() to get al the moves then check if the
            next player can win (????)
            idea (Roderickgao 107 August 13, 2016 1:18 AM): https://leetcode.com/problems/flip-game-ii/discuss/73962/Share-my-Java-backtracking-solution

            as with the combining the two lists problem, here we know how to
                get all possible moves already
                so use that - i am just not clear how THAT part works
             */

            List<string> moves = GeneratePossibleNextMoves(s);

            foreach (string nextMove in moves)
            {
                if (!CanWinUsingFlipGame1(nextMove)) return true;
            }

            return false;
        }

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