using App.Scripts.Modules.Systems;
using App.Scripts.Scenes.SceneMatrix.Features.FigurePreviewContainer.Model;
using App.Scripts.Scenes.SceneMatrix.Features.FigurePreviewContainer.View.ViewFigureContainer;
using App.Scripts.Scenes.SceneMatrix.Features.FigureSwitcher;
using App.Scripts.Scenes.SceneMatrix.Features.Grid.Signals;
using App.Scripts.Scenes.SceneMatrix.Features.Grid.View;
using App.Scripts.Scenes.SceneMatrix.Features.PackLevel.Component;
using App.Scripts.Scenes.SceneMatrix.Features.PackLevel.Model;
using UnityEngine;

namespace App.Scripts.Scenes.SceneMatrix.Features.Grid.Systems
{
    public class SystemRebuildField : ISystem
    {
        private readonly IViewMatrixField _viewMatrixField;
        private readonly ViewFigureContainer _viewFigureContainer;
        public SystemContext Context { get; set; }

        public SystemRebuildField(IViewMatrixField viewMatrixField, ViewFigureContainer viewFigureContainer)
        {
            _viewMatrixField = viewMatrixField;
            _viewFigureContainer = viewFigureContainer;
        }
        
        public void Init()
        {
            Context.Data.SetComponent(new ComponentUsedFigures());
            Context.Data.SetComponent(new ComponentAvailableFigures());
            Context.Data.SetComponent(new ComponentField(new Vector2Int(1, 1)));
        }

        public void Update(float dt)
        {
            if (Context.Signals.TryGetComponent<RequestUpdateLevel>(out _) is false 
                || Context.Data.TryGetComponent<ComponentCurrentLevel>(out var level) is false)
            {
                return;
            }
            
            UpdateField(level.LevelData);
            GenerateFigures(level.LevelData);
        }

        private void GenerateFigures(PackLevelData componentLevelData)
        {
            var availableFigures = Context.Data.GetComponent<ComponentAvailableFigures>();
            var usedFigures = Context.Data.GetComponent<ComponentUsedFigures>();
            availableFigures.Figures.Clear();
            usedFigures.Figures.Clear();

            int index = 0;
            
            foreach (var figure in componentLevelData.Figures)
            {
                var rndColor = new Color(Random.value, Random.value, Random.value, 1);
                var viewFigure = new ViewModelFigure(index, figure, rndColor);
                availableFigures.Figures.Add(viewFigure);
                index++;
            }
            
            _viewFigureContainer.UpdateFigureList(availableFigures.Figures);
        }

        private void UpdateField(PackLevelData componentLevelData)
        {
            _viewMatrixField.UpdateSize(componentLevelData.FieldSize);

            var field = Context.Data.GetComponent<ComponentField>();
            field.Grid.UpdateMatrix(componentLevelData.FieldSize);
            field.Grid.Clear();
        }

        public void Cleanup()
        {
        }
    }
}