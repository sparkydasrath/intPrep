namespace General
{
    public class BacktrackingEscapeMaze
    {
        public static bool EscapeMaze(Maze maze, int row, int col)
        {
            // https://www.youtube.com/watch?v=OTClT85FgMk&list=PLT0wqqmbAFnfdRRCnzqY943MDyaNa3KSy&index=9
            // this is just a code overview as I don't have an actual maze

            // base cases
            if (!maze.InBounds(row, col)) return true;
            if (maze.IsWall(row, col)) return false;
            if (maze.IsOpen(row, col))
            {
                // choose
                maze.Mark(row, col);

                // explore from a single square we can potentially go in 4 directions
                bool result = EscapeMaze(maze, row - 1, col) // up
                              || EscapeMaze(maze, row + 1, col) // down
                              || EscapeMaze(maze, row, col - 1) // left
                              || EscapeMaze(maze, row, col + 1); //right

                // un-choose
                if (!result) maze.Taint(row, col);

                return result;
            }

            return false;
        }
    }
}