using App.Scripts.Features.GridField.GridContainer;
using App.Scripts.Modules.Factory;
using App.Scripts.Modules.Systems;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.Components;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.LevelInfo;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.LevelInfo.Config;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.Obstacles.ObstacleMap;
using App.Scripts.Scenes.SceneHeroes.Features.Units;
using UnityEngine;

namespace App.Scripts.Scenes.SceneHeroes.Features.Grid.Systems
{
    public class SystemRebuildLevel : ISystem
    {
        private readonly IObstacleMap _obstacleMap;
        private readonly IViewGridContainer _viewGridContainer;
        private IFactory<IUnitInfo, Unit> _factoryUnit;
        public SystemContext Context { get; set; }

        public SystemRebuildLevel(IObstacleMap obstacleMap, IViewGridContainer viewGridContainer, IFactory<IUnitInfo, Unit> factoryUnit)
        {
            _obstacleMap = obstacleMap;
            _viewGridContainer = viewGridContainer;
            _factoryUnit = factoryUnit;
        }
        
        public void Init()
        {
        }

        public void Update(float dt)
        {
            if (!Context.Signals.HasComponent<ComponentRequestRebuildLevel>())
            {
                return;
            }

            var rebuildRequest = Context.Signals.GetComponent<ComponentRequestRebuildLevel>();
            RebuildField(rebuildRequest.LevelInfo);
        }

        private void RebuildField(ILevelInfo levelInfo)
        {
            BuildField(levelInfo);
        }

        private void BuildField(ILevelInfo levelInfo)
        {
            Context.Data.SetComponent(levelInfo);
            BuildObstacles(levelInfo);
            BuildUnit(levelInfo);
        }



        private void BuildObstacles(ILevelInfo levelInfo)
        {
            _viewGridContainer.UpdateGrid(levelInfo.Size);
            _obstacleMap.UpdateField(levelInfo.Size);
            
            foreach (ICellObstacle levelInfoObstacle in levelInfo.Obstacles)
            {
                _obstacleMap.SetObstacle(levelInfoObstacle.CellPosition, levelInfoObstacle.Obstacle);
            }

            FillEmptyCells(levelInfo);
        }

        private void FillEmptyCells(ILevelInfo levelInfo)
        {
            for (int i = 0; i < levelInfo.Size.y; i++)
            {
                for (int j = 0; j < levelInfo.Size.x; j++)
                {
                    if (_obstacleMap.GetAt(i, j) == ObstacleType.None)
                    {
                        _obstacleMap.SetObstacle(new Vector2Int(j, i), ObstacleType.None);
                    }
                }
            }
        }
        
        private void BuildUnit(ILevelInfo levelInfo)
        {
            Unit unit = _factoryUnit.Create(levelInfo.Unit);
            unit.PlaceAt(levelInfo.Unit.CellPosition);
            Context.Data.SetComponent(unit);
        }

        public void Cleanup()
        {
        }
    }
}