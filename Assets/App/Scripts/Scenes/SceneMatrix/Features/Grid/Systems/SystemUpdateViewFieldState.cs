using App.Scripts.Modules.Systems;
using App.Scripts.Scenes.SceneMatrix.Features.FieldInteractions.Signal;
using App.Scripts.Scenes.SceneMatrix.Features.FigurePreviewContainer.View.ViewFigureContainer;
using App.Scripts.Scenes.SceneMatrix.Features.FigureSwitcher;
using App.Scripts.Scenes.SceneMatrix.Features.Grid.View;
using App.Scripts.Scenes.SceneMatrix.Features.PackLevel.Component;
using UnityEngine;

namespace App.Scripts.Scenes.SceneMatrix.Features.Grid.Systems
{
    public class SystemUpdateViewFieldState : ISystem
    {
        private readonly IViewMatrixField _viewMatrixField;
        private readonly ViewFigureContainer _viewFigureContainer;
        public SystemContext Context { get; set; }

        public SystemUpdateViewFieldState(IViewMatrixField viewMatrixField, ViewFigureContainer viewFigureContainer)
        {
            _viewMatrixField = viewMatrixField;
            _viewFigureContainer = viewFigureContainer;
        }
        
        public void Init()
        {
            
        }

        public void Update(float dt)
        {
            if (Context.Signals.HasComponent<SignalFieldChanged>() is false)
            {
                return;
            }

            var availableFigures = Context.Data.GetComponent<ComponentAvailableFigures>();
            _viewFigureContainer.UpdateFigureList(availableFigures.Figures);

            UpdateMatrix();
        }

        private void UpdateMatrix()
        {
            var field = Context.Data.GetComponent<ComponentField>();
            var fieldGrid = field.Grid;
            
            for (int i = 0; i < fieldGrid.Height; i++)
            {
                for (int j = 0; j < fieldGrid.Width; j++)
                {
                    var cell = new Vector2Int(j, i);

                    var cellModel = fieldGrid[cell];
                    if (cellModel is null)
                    {
                        _viewMatrixField.ClearCell(cell);
                        continue;
                    }

                    _viewMatrixField.SetCellColor(cell, cellModel.Color);
                }
            }
        }

        public void Cleanup()
        {
        }
    }
}