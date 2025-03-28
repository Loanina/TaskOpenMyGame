using System.Collections.Generic;
using App.Scripts.Modules.GridModel;

namespace App.Scripts.Scenes.SceneMatrix.Features.FigureProvider.Parser
{
    public interface IFigureParser
    {
        /// <summary>
        /// парсит предложенный текст в грид с фигурой
        /// если формат файла неверный то кидается исключение ExceptionParseFigure
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        List<Grid<bool>> ParseFile(string text);
    }
}