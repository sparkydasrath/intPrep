using System;
using System.Collections.Generic;
using System.Text;
// unused using statements

namespace ShootsAndLadders
{
    public class Player
    {
        // inconsistent naming convention
        // use lowercase for private fields
        private int Number;
        private Random Random;



        // both of these methods should be in an auto property
        // ex: public int Number { get; set; }
        public int GetNumber()
        {
            return Number;
        }

        public void SetNumber(int value)
        {
            Number = value;
        }

        public int Move()
        {
            // maybe Move should take in the spaces to move and player can update the state
            if (Random == null) {
                /* from line 23 in program, each player is calling move
                 but a new random is generated for each player
                  we could have a Player constructor that takes a 
                  Random that the Board creates and passes the same instance
                  to each player to use 
                 
                The game is rigged in player 1's favor as he is the only winner. EVER.

                 */
                Random = new Random(Number);
            }
         
            var spaces = Random.Next(0, 6); 
            // should be 1-6, will never roll a 6 because upper bound is included in Random
            Console.WriteLine($"Player {GetNumber()} spun a {spaces}.");
            return spaces;
        }
    }
}
