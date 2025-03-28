using System.Collections.Generic;
using App.Scripts.Scenes.SceneMatrix.Features.FieldInteractions.Model;
using App.Scripts.Scenes.SceneMatrix.Features.FigurePreviewContainer.Model;
using UnityEngine;

namespace App.Scripts.Scenes.SceneMatrix.Features.FieldInteractions.Services
{
    public class ServicePackFieldDummy : IServiceFieldPacker
    {
        public void GeneratePlacements(List<FigurePlacement> outputPlaces, Vector2Int fieldSize, List<ViewModelFigure> figures)
        {
            //тестовая имплементация - перепишите это!
            if (figures.Count == 0)
            {
                return;
            }
            
            outputPlaces.Add(new FigurePlacement
            {
                Id =  figures[0].Id,
                Place = new Vector2Int(0, 0)
            });
        }
    }
}