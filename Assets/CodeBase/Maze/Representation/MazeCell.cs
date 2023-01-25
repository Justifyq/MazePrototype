namespace CodeBase.Maze.Representation
{
    /// <summary>
    /// Базовая реализация клетки для лабиринта
    /// </summary>
    public class MazeCell
    {
        public bool Left;
        public bool Right;
        public bool Forward;
        public bool Back;
        
        public int X;
        public int Y;
        
    }
}