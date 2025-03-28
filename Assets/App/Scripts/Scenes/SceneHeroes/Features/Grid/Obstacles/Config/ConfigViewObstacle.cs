using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace App.Scripts.Scenes.SceneHeroes.Features.Grid.Obstacles.Config
{
    [CreateAssetMenu(fileName = "configViewObstacle", menuName = "app/heroes/obstacle config")]
    public class ConfigViewObstacle : ScriptableObject, IObstacleConfiguration
    {
        
        [SerializeField] private List<ObstacleViewConfig> _obstacles = new();

        [SerializeField]
        private float obstacleLayer;

        public float ObstacleLayer => obstacleLayer;

        public IEnumerable<int> AvailableObstacleTypes => _obstacles.Select(x => x.ObstacleType);

        
        public ObstacleViewConfig FindObstacleConfig(int obstacleType)
        {
            return _obstacles.FirstOrDefault(x => x.ObstacleType == obstacleType);
        }

    }

    [Serializable]
    public class ObstacleViewConfig
    {
        public Sprite spriteObstacle;
        public int ObstacleType;
    }
}