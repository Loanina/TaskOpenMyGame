using App.Scripts.Modules.GridModel;
using UnityEngine;

namespace App.Scripts.Scenes.SceneHeroes.Features.Grid.Obstacles.ObstacleMap
{
    public interface IObstacleMap
    {
        void UpdateField(Vector2Int levelInfoSize);
        void SetObstacle(Vector2Int cellPosition, int obstacleId);
        int GetAt(int i, int j);
        
        void ClearField();
        bool IsValidCell(Vector2Int cellIndex);
        int GetAt(Vector2Int cellIndex);
        Grid<int> ObstacleMap { get;  }
    }
}