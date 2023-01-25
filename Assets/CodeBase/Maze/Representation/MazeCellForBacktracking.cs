namespace CodeBase.Maze.Representation
{
    /// <summary>
    /// Клетка для лабиринта использующий алгоритм поиска с возвратом
    /// </summary>
    public class MazeCellForBacktracking : MazeCell
    {
        public bool IsVisited;
        public int Distance;
        
        public MazeCellForBacktracking(int x, int y)
        {
            X = x;
            Y = y;
            
            Forward = true;
            Back = true;
            Left = true;
            Right = true;
        }
    }
}