using System;
using UnityEngine;

namespace App.Scripts.Scenes.SceneHeroes.Features.Grid.LevelInfo.Serializable
{
    [Serializable]
    public class CellObstacle : ICellObstacle
    {
        [SerializeField]
        private Vector2Int cellPosition;

        [SerializeField]
        private int _obstacle;
        
        public Vector2Int CellPosition => cellPosition;
        public int Obstacle => _obstacle;

        
        public CellObstacle(Vector2Int position, int type)
        {
            cellPosition = position;
            _obstacle = type;
        }
    }
}