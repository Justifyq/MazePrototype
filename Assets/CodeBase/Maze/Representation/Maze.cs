namespace CodeBase.Maze.Representation
{
    /// <summary>
    /// Лабиринт.
    /// </summary>
    public class Maze
    {        
        /// <summary>
        /// Клетки лабиринта.
        /// </summary>
        public readonly MazeCell[,] Cells;

        public readonly MazeCell StartPoint;
        
        /// <summary>
        /// Финальная точка лабиринта.
        /// </summary>
        public readonly MazeCell EndPoint;
        
        public Maze(MazeCell[,] cells, MazeCell startPoint, MazeCell endPoint)
        {
            Cells = cells;
            StartPoint = startPoint;
            EndPoint = endPoint;
        }

    }
}