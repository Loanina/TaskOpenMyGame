using System;

namespace App.Scripts.Scenes.SceneCalculator.Features.Process.InputExpression
{
    public interface IViewInputExpression
    {
        public string Key { get; }
        public string Expression { get; }

        public event Action OnApply;
    }
}