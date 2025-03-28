using System;

namespace App.Scripts.Scenes.SceneMatrix.Features.FigureProvider.Parser
{
    
    /// <summary>
    /// исключение при парсинге текста в матрицу с информацией о фигуре
    /// </summary>
    public class ExceptionParseFigure : Exception
    {
        public ExceptionParseFigure(string message) : base(message)
        {
            
        }
    }
}