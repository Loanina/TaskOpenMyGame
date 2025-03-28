using System;
using System.Collections.Generic;
using System.Linq;
using App.Scripts.Modules.Systems;
using App.Scripts.Scenes.SceneHeroes.Features.Grid;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.Obstacles;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.Obstacles.Config;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.Obstacles.ObstacleMap;
using UnityEngine;

namespace App.Scripts.Scenes.SceneHeroes.Features.GameInput.Services.Handlers
{
    public class HandlerUpdateObstacle : IHandlerFieldClick
    {
        private readonly IObstacleMap _obstacleMap;
        private readonly List<int> _availableObstacles;

        public HandlerUpdateObstacle(IObstacleMap obstacleMap, IObstacleConfiguration obstacleConfiguration)
        {
            _obstacleMap = obstacleMap;
            _availableObstacles = obstacleConfiguration.AvailableObstacleTypes.ToList();

        }
        
        public void ProcessGridClick(SystemContext context, Vector2Int cellIndex)
        {
            var obstacle = _obstacleMap.GetAt(cellIndex);
            var index = _availableObstacles.IndexOf(obstacle);
            index++;
            if (index >= _availableObstacles.Count)
            {
                index = 0;
            }
            _obstacleMap.SetObstacle(cellIndex, _availableObstacles[index]);
        }

        public void Reset()
        {
        }
    }
}