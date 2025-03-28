namespace App.Scripts.Scenes.SceneCalculator.Features.Calculator
{
    public class CalculatorExpression : ICalculatorExpression
    {

        public float Execute(string expression)
        {
            return 8;
        }

        public void SetExpression(string expressionKey, string expression)
        {
        }

        public void SetValue(string key, float value)
        {
            throw new System.NotImplementedException();
        }

        public float Get(string expressionKey)
        {
            return 6;
        }
    }
}