using App.Scripts.Features.GridField.GridContainer;
using App.Scripts.Modules.Factory;
using App.Scripts.Modules.GridModel;
using UnityEngine;

namespace App.Scripts.Scenes.SceneMatrix.Features.Grid.View
{
    public class ViewMatrixField : IViewMatrixField
    {
        private readonly SettingsMatrixField _settings;
        private readonly IViewGridContainer _viewGridContainer;
        private readonly IFactory<ViewCell> _factory;

        private Grid<ViewCell> _viewGrid;

        public ViewMatrixField(SettingsMatrixField settings, IViewGridContainer viewGridContainer, IFactory<ViewCell> factory)
        {
            _settings = settings;
            _viewGridContainer = viewGridContainer;
            _factory = factory;
        }

        public void Clear()
        {
            _viewGridContainer.ClearCells();
        }

        public void UpdateSize(Vector2Int size)
        {
            Clear();
            _viewGrid = new Grid<ViewCell>(size);
            
            _viewGridContainer.UpdateGrid(size);
            for (int i = 0; i < size.y; i++)
            {
                for (int j = 0; j < size.x; j++)
                {
                    var bgView = _factory.Create();
                    bgView.SetColor(_settings.colorBg);
                    _viewGridContainer.AddViewCell(bgView, new Vector2Int(j, i));
                    _viewGrid[new Vector2Int(j, i)] = bgView;
                }
            }
        }

        public void ClearCell(Vector2Int cell)
        {
            SetCellColor(cell, _settings.colorBg);
        }

        public void SetCellColor(Vector2Int cell, Color color)
        {
            _viewGrid[cell].SetColor(color);
        }
    }
}