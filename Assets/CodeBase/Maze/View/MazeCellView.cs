using CodeBase.Maze.Representation;
using UnityEngine;

namespace CodeBase.Maze.View
{
    /// <summary>
    /// Вью клетки
    /// </summary>
    public class MazeCellView : MonoBehaviour
    {
        [SerializeField] private GameObject left;
        [SerializeField] private GameObject right;
        [SerializeField] private GameObject forward;
        [SerializeField] private GameObject back;
        
        /// <summary>
        /// Установить вью для клетки
        /// </summary>
        public void SetView(MazeCell cell)
        {
            left.SetActive(cell.Left);
            right.SetActive(cell.Right);
            forward.SetActive(cell.Forward);
            back.SetActive(cell.Back);
        }
    }
}