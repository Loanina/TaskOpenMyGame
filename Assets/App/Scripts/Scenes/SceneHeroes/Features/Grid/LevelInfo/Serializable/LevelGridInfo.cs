using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.Scenes.SceneHeroes.Features.Grid.LevelInfo.Serializable
{
    public class LevelGridInfo : ILevelInfo
    {
        public Vector2Int Size { get; }
        public IEnumerable<ICellObstacle> Obstacles => _obstacles;
        public IUnitInfo Unit { get; }

        private readonly List<ICellObstacle> _obstacles = new();

        public LevelGridInfo(Vector2Int size, IEnumerable<ICellObstacle> obstacles, IUnitInfo unitInfo)
        {
            Size = size;
            _obstacles.AddRange(obstacles);
            Unit = unitInfo;
        }
    
    }
}