using App.Scripts.Modules.GridModel;

namespace App.Scripts.Scenes.SceneMatrix.Features.FigureProvider
{
    public interface IFigureProvider
    {
        int TotalFiguresCount { get; }

        Grid<bool> GetFigure(int index);
    }
}