using System;
using System.Collections.Generic;
using App.Scripts.Modules.GridModel;
using App.Scripts.Modules.Systems;
using App.Scripts.Scenes.SceneMatrix.Features.FieldInteractions.Model;
using App.Scripts.Scenes.SceneMatrix.Features.FieldInteractions.Services;
using App.Scripts.Scenes.SceneMatrix.Features.FieldInteractions.Signal;
using App.Scripts.Scenes.SceneMatrix.Features.FigurePreviewContainer.Model;
using App.Scripts.Scenes.SceneMatrix.Features.FigureSwitcher;
using App.Scripts.Scenes.SceneMatrix.Features.PackLevel.Component;
using App.Scripts.Scenes.SceneMatrix.Features.PackLevel.Model;
using UnityEngine;

namespace App.Scripts.Scenes.SceneMatrix.Features.FieldInteractions.Systems
{
    public class SystemProcessPackFigures : ISystem
    {
        private readonly IServiceFieldPacker _serviceFieldPacker;
        private readonly List<FigurePlacement> _placements = new ();
        public SystemContext Context { get; set; }

        public SystemProcessPackFigures(IServiceFieldPacker serviceFieldPacker)
        {
            _serviceFieldPacker = serviceFieldPacker;
        }
        
        public void Init()
        {
        }

        public void Update(float dt)
        {
            if (Context.Signals.HasComponent<SignalPackField>() is false)
            {
                return;
            }

            var availableFigures = Context.Data.GetComponent<ComponentAvailableFigures>();
            var usedFigures = Context.Data.GetComponent<ComponentUsedFigures>();
            var field = Context.Data.GetComponent<ComponentField>();

            var fieldGrid = field.Grid;
            if (IsEmpty(fieldGrid) is false)
            {
                Debug.Log("field not empty reset it");
                return;
            }
            
            _placements.Clear();
            _serviceFieldPacker.GeneratePlacements(_placements, fieldGrid.Size, availableFigures.Figures);

            foreach (FigurePlacement figurePlacement in _placements)
            {
                var figure = availableFigures.Figures.Find(x => x.Id == figurePlacement.Id);
                
                if (figure is null)
                {
                    Debug.LogError($"cant find figure for place {figurePlacement.Id}");
                    continue;
                }
                
                Place(fieldGrid, figure, figurePlacement.Place);

                availableFigures.Figures.Remove(figure);
                usedFigures.Figures.Add(figure);
            }
    
            Context.Signals.SetComponent(new SignalFieldChanged());
        }

        private void Place(Grid<CellModel> fieldGrid, ViewModelFigure figureModel, Vector2Int place)
        {
            var figureGrid = figureModel.Grid;
            
            for (int i = 0; i < figureGrid.Height; i++)
            {
                for (int j = 0; j < figureGrid.Width; j++)
                {
                    PlaceCell(fieldGrid, figureModel, place, new Vector2Int(j, i));
                }
            }
        }

        private static void PlaceCell(Grid<CellModel> fieldGrid, ViewModelFigure figureModel, Vector2Int place, Vector2Int cell)
        {
            var figureGrid = figureModel.Grid;

            if (figureGrid[cell] is false) return;
            var nextPlace = place + cell;

            if (nextPlace.x < 0 || nextPlace.y < 0 ||
                nextPlace.x >= fieldGrid.Width || nextPlace.y >= fieldGrid.Height)
            {
                throw new Exception($"cant place at {nextPlace}");
            }
                    
            fieldGrid[nextPlace] = new CellModel
            {
                Color = figureModel.Color,
                IdFigure = figureModel.Id
            };
        }

        private bool IsEmpty(Grid<CellModel> fieldGrid)
        {
            for (int i = 0; i < fieldGrid.Height; i++)
            {
                for (int j = 0; j < fieldGrid.Width; j++)
                {
                    if (fieldGrid[j, i] != null) return false;
                }
            }

            return true;
        }
        
        public void Cleanup()
        {
        }
    }
}