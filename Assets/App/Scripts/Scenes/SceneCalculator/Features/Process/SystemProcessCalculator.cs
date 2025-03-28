using App.Scripts.Modules.Systems;
using App.Scripts.Scenes.SceneCalculator.Features.Calculator;
using App.Scripts.Scenes.SceneCalculator.Features.Process.InputExpression;
using App.Scripts.Scenes.SceneCalculator.Features.ViewLog;

namespace App.Scripts.Scenes.SceneCalculator.Features.Process
{
    public class SystemProcessCalculator : ISystem
    {
        private readonly IViewLog _viewLog;
        private readonly IViewInputExpression _inputExpression;
        private readonly IViewInputExpression _executeExpression;
        private readonly ICalculatorExpression _calculatorExpression;
        public SystemContext Context { get; set; }

        public SystemProcessCalculator(IViewLog viewLog, 
            IViewInputExpression inputExpression, 
            IViewInputExpression executeExpression, 
            ICalculatorExpression calculatorExpression)
        {
            _viewLog = viewLog;
            _inputExpression = inputExpression;
            _executeExpression = executeExpression;
            _calculatorExpression = calculatorExpression;
        }

        public void Init()
        {
            _inputExpression.OnApply += OnSetExpression;
            _executeExpression.OnApply += OnApplyExpression;
            
        }

        private void OnSetExpression()
        {
            _calculatorExpression.SetExpression(_inputExpression.Key, _inputExpression.Expression);
            LogMessage($"Add expression {_inputExpression.Key} = {_inputExpression.Expression}");
        }

        private void OnApplyExpression()
        {
            var result = _calculatorExpression.Execute(_executeExpression.Expression);
            LogMessage($"Execute expression {_executeExpression.Expression} = {result.ToString()}");
        }
        
        private void LogMessage(string message)
        {
            _viewLog.AddLog(message);
        }

        public void Update(float dt)
        {
        }

        public void Cleanup()
        {
            _inputExpression.OnApply -= OnApplyExpression;
            _executeExpression.OnApply -= OnSetExpression;
        }
    }
}