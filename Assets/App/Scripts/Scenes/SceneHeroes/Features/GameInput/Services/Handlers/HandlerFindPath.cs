using App.Scripts.Modules.Systems;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.Obstacles.ObstacleMap;
using App.Scripts.Scenes.SceneHeroes.Features.PathFinding;
using App.Scripts.Scenes.SceneHeroes.Features.PathFinding.PathDrawer;
using App.Scripts.Scenes.SceneHeroes.Features.Units;
using UnityEngine;

namespace App.Scripts.Scenes.SceneHeroes.Features.GameInput.Services.Handlers
{
    public class HandlerFindPath : IHandlerFieldClick
    {
        private readonly IViewPath _viewPath;
        private readonly IObstacleMap _obstacleMap;
        private readonly IServiceUnitNavigator _serviceUnitNavigator;

        public HandlerFindPath(IViewPath viewPath, IObstacleMap obstacleMap, IServiceUnitNavigator serviceUnitNavigator)
        {
            _viewPath = viewPath;
            _obstacleMap = obstacleMap;
            _serviceUnitNavigator = serviceUnitNavigator;
        }
        
        public void ProcessGridClick(SystemContext context, Vector2Int cellIndex)
        {
            _viewPath.Reset();
            
            var unit = context.Data.GetComponent<Unit>();

            if (unit is null)
            {
                return;
            }

            var path = _serviceUnitNavigator.FindPath(unit.UnitType, unit.CellPosition, cellIndex, _obstacleMap.ObstacleMap);

            if (path is null || path.Count <= 1)
            {
                return;
            }
            
            _viewPath.DrawCellPath(path);
        }

        public void Reset()
        {
            _viewPath.Reset();
        }
    }
}