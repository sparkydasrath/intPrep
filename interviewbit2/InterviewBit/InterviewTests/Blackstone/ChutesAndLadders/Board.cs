using System.Collections.Generic;
// unused using statements

namespace ShootsAndLadders
{
    public class Board
    {
        // these can be made read only as they are only mutated in this class
        public List<Square> Squares { get; set; }
        public List<Player> Players { get; set; }

        public Board(int numberOfPlayers)
        { // inconsistent use of opening brace
           
            Players = new List<Player>();
            Squares = new List<Square>();

            /*
                 Lot of things happening in this constructor
                 I would move populating the players and setting 
                 up the board to their own methods
             */

            //FIXED: Start at 1, Starting at Player 0 was bad.
            // you don't say..... why???
            // numberOfPlayers is never used - the board is always stuck at using 2 players
            for (int i = 1; i < 3; i++)
            {
                var nextPlayer = new Player();
                nextPlayer.SetNumber(i);
                Players.Add(nextPlayer);
            }

            // this condition creates a board with 101 cells instead of 100
            for (var j = 0; j <= 100; j++)
            {
                var newSquare = new Square();
                Squares.Add(newSquare);

                /* the layout of the board is static, there is no way to vary it
                   I would also add something like ShootFrom and Ladder from in the Square class
                   To provide more flexibility, we can do either
                   1. provide overloaded constructors in Square to build out the c/l on creation
                      ex: public Square(int ladderFrom, int ladderTo)

                In the default constructor, you can get the from/to to be -1 if there is no connection there

                  2. Provide helper method to accomplish the same thing, so you can new up a bunch of Squares
                      then set the c/l

                  Either way, you can even have the user/board provide a csv file that defines all the connection
                  info that you can use to dynamically generate various boards

                  I prefer option 1 as you set up state on construction rather than having to create the square
                  then going back to set up the c/l

      */
                if (j == 10)
                {
                    newSquare.LadderTo = 18;
                }
                else if (j == 20)
                {
                    newSquare.ShootTo = 14;
                }
                else if (j == 24)
                {
                    newSquare.LadderTo = 35;
                }
                else if (j == 30)
                {
                    newSquare.LadderTo = 40;
                }
                else if (j == 32)
                {
                    newSquare.ShootTo = 15;
                }
                else if (j == 41)
                {
                    newSquare.LadderTo = 57;
                }
                else if (j == 45)
                {
                    newSquare.LadderTo = 55;
                }
                else if (j == 48)
                {
                    newSquare.LadderTo = 60;
                }
                else if (j == 50)
                {
                    newSquare.ShootTo = 25;
                }
                else if (j == 51)
                {
                    newSquare.ShootTo = 64;
                }
                else if (j == 61)
                {
                    newSquare.ShootTo = 43;
                }
                else if (j == 63)
                {
                    newSquare.LadderTo = 70;
                }
                else if (j == 78)
                {
                    newSquare.ShootTo = 65;
                }
                else if (j == 80)
                {
                    newSquare.LadderTo = 100;
                }
                else if (j == 48)
                {
                    newSquare.LadderTo = 53;
                }

            }

            Squares[0].Players.AddRange(Players);
        }
    }
}
