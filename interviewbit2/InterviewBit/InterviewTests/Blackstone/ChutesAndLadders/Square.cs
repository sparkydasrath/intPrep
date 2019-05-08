using System.Collections.Generic;
// unused using statements

namespace ShootsAndLadders
{
    public class Square
    {

        // I don't like the Square knowing about a list of players

        // can be made private since it's only initialized in this class
        // remove the setter
        // better question: why is the square new-ing up Players, this is breaking
        // the SRP principle 
        public List<Player> Players { get; set; }

        // no need to make these nullable
        // this is a game using natural numbers
        // the concept of a null location is misleading in this case
        public int? ShootTo { get; set; }
        public int? LadderTo { get; set; }

        /*

            THIS IS DEBATABLE
            would want to add these so you have more control when building the board

            public int ShootFrom { get; set; }
            public int LadderFrom { get; set; }


            // use this to help with indexing into the Squares list
            public int SquareNumber { get; set; } 

        */

        public Square()
        {

            Players = new List<Player>();
        }
    }
}
