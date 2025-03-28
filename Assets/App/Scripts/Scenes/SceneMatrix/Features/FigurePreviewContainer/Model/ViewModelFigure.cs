using App.Scripts.Modules.GridModel;
using UnityEngine;

namespace App.Scripts.Scenes.SceneMatrix.Features.FigurePreviewContainer.Model
{
    public class ViewModelFigure
    {
        public int Id;
        public Color Color;
        public Grid<bool> Grid;

        public ViewModelFigure(int id, Grid<bool> figure, Color color)
        {
            Id = id;
            Grid = figure;
            Color = color;
        }
    }
}