using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Maze.Generation
{
    using  Representation;
    
    /// <summary>
    /// Генератор доски с исользованием алгоритма поиск с возвратом.
    /// https://weblog.jamisbuck.org/2010/12/27/maze-generation-recursive-backtracking
    /// </summary>
    public class RecursiveBacktrackingMazeGenerator : IMazeGenerator
    {
        private int _width;
        private int _length;
        
        /// <summary>
        /// Сгенерировать лабиринт
        /// </summary>
        public Maze GenerateMaze(int width, int length)
        {
            _length = length;
            _width = width;

            var cells = GenerateMazeGrid();
            cells = RemoveWallsFromMaze(cells);
            
            return new Maze(cells, cells[0,0], GetFarthestCell(cells));
        }

        private MazeCellForBacktracking[,] GenerateMazeGrid()
        {
            var mazeCells = new MazeCellForBacktracking[_width, _length];

            for (var x = 0; x < _width; x++)
            {
                for (var y = 0; y < _length; y++) 
                    mazeCells[x, y] = new MazeCellForBacktracking(x, y);
            }

            return mazeCells;
        }

        private MazeCellForBacktracking GetFarthestCell(MazeCellForBacktracking[,] cells)
        {
            var farthestPoint = cells[0,0];

            for (var x = 0; x < cells.GetLength(0); x++)
            {
                if (cells[x, _length - 1].Distance > farthestPoint.Distance) 
                    farthestPoint = cells[x, _length - 1];
            }
        
            for (var y = 0; y < cells.GetLength(1); y++)
            {
                if (cells[_width -1, y].Distance > farthestPoint.Distance) 
                    farthestPoint = cells[_width - 1, y];
            }


            return farthestPoint;
        }

        private MazeCellForBacktracking[,] RemoveWallsFromMaze(MazeCellForBacktracking[,] mazeCells)
        {
            var current = mazeCells[0, 0];
            current.IsVisited = true;
            var stack = new Stack<MazeCellForBacktracking>();
            current.Distance = 0;
            stack.Push(current);
        
            while (stack.Count > 0)
            {
                var unvisited = new List<MazeCellForBacktracking>();

                var x = current.X;
                var y = current.Y;

                if (current.X > 0 && mazeCells[x - 1, y].IsVisited == false)
                    unvisited.Add(mazeCells[x - 1, y]);

                if (y > 0 && mazeCells[x, y - 1].IsVisited == false)
                    unvisited.Add(mazeCells[x, y - 1]);

                if (x < _width - 1 && mazeCells[x + 1, y].IsVisited == false)
                    unvisited.Add(mazeCells[x + 1, y]);

                if (y < _length - 1 && mazeCells[x, y + 1].IsVisited == false)
                    unvisited.Add(mazeCells[x, y + 1]);

                if (unvisited.Count > 0)
                {
                    var randomUnvisited = unvisited[Random.Range(0, unvisited.Count)];
                
                    RemoveWall(current, randomUnvisited);
                
                    randomUnvisited.IsVisited = true;
                    current = randomUnvisited;
                    stack.Push(current);
                    current.Distance = stack.Count;
                    continue;
                }

                current = stack.Pop();
                
            }
            
            return mazeCells;
        }

        private void RemoveWall(MazeCell current, MazeCell chosen)
        {
            if (current.X == chosen.X)
            {
                if (current.Y > chosen.Y)
                {
                    current.Back = false;
                    chosen.Forward = false;
                }
                else
                {
                    chosen.Back = false;
                    current.Forward = false;
                }
            
            }
            else
            {
                if (current.X > chosen.X)
                {
                    current.Left = false;
                    chosen.Right = false;
                }
                else
                {
                    chosen.Left = false;
                    current.Right = false;
                }
            }
            
        }
    }
}