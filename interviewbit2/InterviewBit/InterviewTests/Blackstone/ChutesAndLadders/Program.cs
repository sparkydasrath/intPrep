namespace ShootsAndLadders
{
    /*class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to shoots and ladders! How many players?");
                // will throw format exception if you hit return (empty string)
                // or enter anything other than a number
                string numberOfPlayers = Console.ReadLine();
                // inconsistent use of concrete type vs. var
                var board = new Board(int.Parse(numberOfPlayers));
                while (!board.Squares.Last().Players.Any())
                {
                    // instead of this while loop, we can just track the max score for each player
                    // and break out as soon as it reaches 100


                    // DESIGN: Maybe have another class called KeepScore/GameEngine that knows when someone wins


                    // if we make the player responsible for reporting its position
                    // we can prob get rid of this while loop

                    foreach (var player in board.Players)
                    {
                        // giant block of text, not the end of the world to 
                        //  add some lines to make it more readable or use helper methods so it reads like a set of moves

                        // this always runs through the list of squares looking the current player
                        // since we know the size of the board, can keep a track of where each player is and just index into the current
                        // Squares to get the square this player is on
                        var currentSquare = board.Squares.Single(x => x.Players.Any(y => y.GetNumber() == player.GetNumber()));
                        // same idea, if we track where the player is in the Player class, we can easily get the square
                        var currentSquareIndex = board.Squares.IndexOf(currentSquare);
                        var move = player.Move();
                        var newSquare = currentSquareIndex + move;
                        // since Squares is a list, use the Count property on it
                        //  rather than the LINQ Count()
                        // doing this bypasses the check that Count() does to see if the object
                        //  is an ICollection cause if it is, is just returns Count anyway
                        if (newSquare >= board.Squares.Count())
                        {
                            // based on coding styles used, you can prob remove these braces
                            //  but it depends on personal/team preferences
                            newSquare = currentSquareIndex;
                        }
                        currentSquare.Players.Remove(player);
                        Console.WriteLine($"Player {player.GetNumber()} moved to square {newSquare}.");
                        if (board.Squares[newSquare].LadderTo.HasValue) 
                        {
                            // can check if value is -1 rather than introduce null int
                            newSquare = board.Squares[newSquare].LadderTo.GetValueOrDefault();
                            Console.WriteLine($"You took a ladder to {newSquare}!");
                        }
                        if (board.Squares[newSquare].ShootTo.HasValue)
                        {
                            newSquare = board.Squares[newSquare].ShootTo.GetValueOrDefault();
                            Console.WriteLine($"You took a ladder to {newSquare}!");
                        }
                        board.Squares[newSquare].Players.Add(player);
                    }
                }
                var winner = board.Squares.Last().Players.First().GetNumber();                
                Console.WriteLine($"Play {winner} wins the game!");
                // inconsistent cases being used: Y/n vs. Y/N or y/n
                Console.WriteLine("Would you like to play again? Y/n");
                var playAgain = Console.ReadLine();
                // case sensitivity not checked, if you enter
                //  just n the game restarts, it shouldn't matter if user
                //  enters n or N to quit
                if (playAgain.StartsWith("N"))
                {
                    return;
                }
            }
        }
    }*/
}