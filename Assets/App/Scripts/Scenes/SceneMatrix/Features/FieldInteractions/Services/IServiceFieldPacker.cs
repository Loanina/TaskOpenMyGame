using System.Collections.Generic;
using App.Scripts.Scenes.SceneMatrix.Features.FieldInteractions.Model;
using App.Scripts.Scenes.SceneMatrix.Features.FigurePreviewContainer.Model;
using UnityEngine;

namespace App.Scripts.Scenes.SceneMatrix.Features.FieldInteractions.Services
{
    public interface IServiceFieldPacker
    {
        void GeneratePlacements(List<FigurePlacement> outputPlaces, Vector2Int fieldSize, List<ViewModelFigure> figures);
    }
}