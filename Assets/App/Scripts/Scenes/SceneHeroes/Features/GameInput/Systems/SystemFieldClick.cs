using App.Scripts.Features.GridField.GridContainer;
using App.Scripts.Modules.Systems;
using App.Scripts.Scenes.SceneHeroes.Features.GameInput.Services;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.Obstacles.ObstacleMap;
using UnityEngine;

namespace App.Scripts.Scenes.SceneHeroes.Features.GameInput.Systems
{
    public class SystemFieldClick : ISystem
    {
        private readonly Camera _camera;
        private readonly IViewGridContainer _viewGridContainer;
        private readonly IObstacleMap _obstacleMap;
        private readonly IHandlerFieldClick _handlerFieldClick;
        public SystemContext Context { get; set; }

        public SystemFieldClick(Camera camera, IViewGridContainer viewGridContainer, IObstacleMap obstacleMap, 
            IHandlerFieldClick handlerFieldClick)
        {
            _camera = camera;
            _viewGridContainer = viewGridContainer;
            _obstacleMap = obstacleMap;
            _handlerFieldClick = handlerFieldClick;
        }
        
        public void Init()
        {
        }

        public void Update(float dt)
        {
            if (Input.GetMouseButtonUp(0) is false)
            {
                return;
            }
            
            Vector2Int cellIndex = GetClickCell();

            if (IsValidCell(cellIndex))
            {
                ProcessClick(cellIndex);
            }
        }

        private Vector2Int GetClickCell()
        {
            var worldClick = _camera.ScreenToWorldPoint(Input.mousePosition);
            Vector2Int cellIndex = _viewGridContainer.GetCellByPos(worldClick);
            return cellIndex;
        }

        private bool IsValidCell(Vector2Int cellIndex)
        {
            return _obstacleMap.IsValidCell(cellIndex);
        }

        private void ProcessClick(Vector2Int cellIndex)
        {
            _handlerFieldClick.ProcessGridClick(Context, cellIndex);
        }

        public void Cleanup()
        {
        }
    }
}