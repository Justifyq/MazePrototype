using CodeBase.Maze.View;
using UnityEngine;

public class MazeConditionSpawner : MonoBehaviour
{
    [SerializeField] private MazeSpawner spawner;
    [SerializeField] private Target target;
    [SerializeField] private CharacterMovement player;
    
    private void Awake() => 
        target.OnPlayerInteracted += SpawnMaze;

    private void Start() => 
        SpawnMaze();

    private void OnDestroy() => 
        target.OnPlayerInteracted -= SpawnMaze;

    private void SpawnMaze()
    {
        var points = spawner.SpawnMaze();
        target.UpdatePosition(points.End);
    }
}
