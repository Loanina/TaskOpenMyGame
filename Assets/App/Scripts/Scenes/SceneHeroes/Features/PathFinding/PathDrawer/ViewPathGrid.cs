using System;
using System.Collections.Generic;
using App.Scripts.Features.GridField.GridContainer;
using App.Scripts.Modules.Factory;
using App.Scripts.Scenes.SceneHeroes.Features.PathFinding.PathLineDrawer;
using UnityEngine;

namespace App.Scripts.Scenes.SceneHeroes.Features.PathFinding.PathDrawer
{
    public class ViewPathGrid : IViewPath
    {
        private readonly IViewGridContainer _viewGridContainer;
        private readonly IFactory<ViewCell> _factory;
        private readonly IPathLineDrawer _pathLineDrawer;
        private readonly Config _config;

        private readonly List<ViewCell> _pathCells = new ();

        public ViewPathGrid(IViewGridContainer viewGridContainer, IFactory<ViewCell> factory, IPathLineDrawer pathLineDrawer, Config config)
        {
            _viewGridContainer = viewGridContainer;
            _factory = factory;
            _pathLineDrawer = pathLineDrawer;
            _config = config;
        }
        
        public void DrawCellPath(List<Vector2Int> path)
        {
            Reset();
            
            foreach (Vector2Int cellPath in path)
            {
                var pathCellView = _factory.Create();
                pathCellView.SetColor(_config.pathColor);
                pathCellView.SetLayer(_config.PathLayer);
                _viewGridContainer.AddViewCell(pathCellView, cellPath);
                _pathCells.Add(pathCellView);
                _pathLineDrawer.AddPoint(_viewGridContainer.GridToPosition(cellPath));
            }
        }
        
        public void Reset()
        {
            _pathLineDrawer.Reset();
            
            foreach (ViewCell pathCell in _pathCells)
            {
                pathCell.Remove();
            }
            
            _pathCells.Clear();
        }
        
        [Serializable]
        public class Config
        {
            public Color pathColor;
            public float PathLayer;
        }
    }
}