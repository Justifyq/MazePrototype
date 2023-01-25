namespace CodeBase.Maze.Generation
{
    using  Representation;
    
    public interface IMazeGenerator
    {
        Maze GenerateMaze(int width, int length);
    }
}