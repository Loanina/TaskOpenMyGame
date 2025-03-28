using System;

namespace App.Scripts.Scenes.SceneCalculator.Features.Calculator
{
    public class ExceptionExecuteExpression : Exception
    {
        public ExceptionExecuteExpression(string message) : base(message)
        {
        }
    }
}