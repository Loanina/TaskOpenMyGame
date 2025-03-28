using App.Scripts.Features.GridField.GridContainer;
using App.Scripts.Modules.Factory;
using App.Scripts.Modules.GridModel;
using UnityEngine;

namespace App.Scripts.Scenes.SceneHeroes.Features.Grid.Obstacles.ObstacleMap
{
    public class ObstacleMapGrid : IObstacleMap
    {
        private readonly IViewGridContainer _viewGridContainer;
        private readonly IFactory<int, ViewCell> _factoryViewObstacle;

        private Grid<int> _obstacles;
        private Grid<ViewCell> _obstaclesViews;

        public Grid<int> ObstacleMap => _obstacles;

        
        public ObstacleMapGrid(IViewGridContainer viewGridContainer, IFactory<int, ViewCell> factoryViewObstacle)
        {
            _viewGridContainer = viewGridContainer;
            _factoryViewObstacle = factoryViewObstacle;
        }
        
        public void UpdateField(Vector2Int levelInfoSize)
        {
            ClearField();
            
            _obstacles = new Grid<int>(levelInfoSize);
            _obstaclesViews = new Grid<ViewCell>(levelInfoSize);
        }

        public void ClearField()
        {
            if (_obstaclesViews is null)
            {
                return;
            }
            
            for (int i = 0; i < _obstaclesViews.Height; i++)
            {
                for (int j = 0; j < _obstaclesViews.Width; j++)
                {
                    ClearView(new Vector2Int(j, i));
                }   
            }
        }

        public bool IsValidCell(Vector2Int cellIndex)
        {
            return _obstacles.IsValid(cellIndex);
        }

        public int GetAt(Vector2Int cellIndex)
        {
            return _obstacles[cellIndex];
        }


        public int GetAt(int i, int j)
        {
            return _obstacles[j, i];
        }

        public void SetObstacle(Vector2Int cellPosition, int obstacle)
        {
            ClearView(cellPosition);
            
            var view = _factoryViewObstacle.Create(obstacle);
            _obstaclesViews[cellPosition] = view;
            _obstacles[cellPosition] = obstacle;
            _viewGridContainer.AddViewCell(view, cellPosition);
        }

        private void ClearView(Vector2Int cellPosition)
        {
            if (_obstaclesViews[cellPosition] is null)
            {
                return;
            }
            
            _obstaclesViews[cellPosition].Remove();
            _obstaclesViews[cellPosition] = null;
        }
    }
}