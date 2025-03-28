namespace App.Scripts.Scenes.SceneCalculator.Features.Calculator
{
    public interface ICalculatorExpression
    {
        /// <summary>
        /// выполняет выражение, если в нем есть переменные пробует их подставить
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        float Execute(string expression);
        
        /// <summary>
        /// устанавливает переменную и выражение для нее внутри калькулятора, при обращении по этому ключу
        /// будет вычисляться это выражение
        /// </summary>
        /// <param name="expressionKey"></param>
        /// <param name="expression"></param>
        void SetExpression(string expressionKey, string expression);

        
        /// <summary>
        /// устанавливает для заданного ключа значение
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void SetValue(string key, float value);
        
        /// <summary>
        /// запрашиваем выражение по ключу и выполняем его
        /// </summary>
        /// <param name="expressionKey"></param>
        /// <returns></returns>
        float Get(string expressionKey);
    }
}