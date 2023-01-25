using CodeBase.Maze.Generation;
using UnityEngine;

namespace CodeBase.Maze.View
{
    using  Representation;
    
    /// <summary>
    /// Спавнер лабиритнта
    /// </summary>
    public class MazeSpawner : MonoBehaviour
    {
        [SerializeField] private MazeCellView cellPrefab;

        [SerializeField] private int width;
        [SerializeField] private int lenght;

        private readonly MazeTargetPoints _mazePoints = new MazeTargetPoints();
        private readonly IMazeGenerator _generator = new RecursiveBacktrackingMazeGenerator();

        private bool isSpawned;

        private MazeCellView[,] spawnedViews;
        
        public MazeTargetPoints SpawnMaze()
        {
            if (isSpawned == false)
                spawnedViews = new MazeCellView[width, lenght];
            
            var maze = _generator.GenerateMaze(width, lenght);
            CreateMaze(maze);
            
            return _mazePoints;
        }

        private void CreateMaze(Maze maze)
        {
            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < lenght; y++)
                {
                    var mazeCell = maze.Cells[x, y];
                    
                    if (isSpawned == false)
                        spawnedViews[x, y] = Instantiate(cellPrefab, new Vector3(x, 0, y), Quaternion.identity, gameObject.transform);

                    var cell = spawnedViews[x, y];
                    

                    CheckMazePoint(maze, mazeCell, cell);

                    cell.SetView(mazeCell);
                }
            }

            isSpawned = true;
        }

        private void CheckMazePoint(Maze maze, MazeCell mazeCell, MazeCellView cellView)
        {
            if (mazeCell == maze.StartPoint)
                _mazePoints.Start = cellView.transform.position;

            if (mazeCell == maze.EndPoint)
                _mazePoints.End = cellView.transform.position;
        }
    }
}