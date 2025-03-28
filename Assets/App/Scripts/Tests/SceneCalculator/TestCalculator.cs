using App.Scripts.Scenes.SceneCalculator.Features.Calculator;
using NUnit.Framework;
using Tests.App.Scripts.Tests.SceneCalculator;
using UnityEngine;
using UnityEngine.TestTools.Constraints;
using File = System.IO.File;
using Is = NUnit.Framework.Is;


public class TestCalculator
{
    private const string PathTestCase = "Assets/App/Scripts/Tests/SceneCalculator/TestCases/{0}.json";
    
    [Test]
    [TestCase("3 +5", 8)]
    [TestCase("-3 +5", 2)]
    [TestCase("2 - (3 +5) ", -6)]
    [TestCase("8 *2 - (3 +5)  ", 8)]
    public void TestCalculatorOneLineExpression(string expression, int expected)
    {
        var calculator = new CalculatorExpression();

        var result = calculator.Execute(expression);

        Assert.AreEqual(expected, result);
    }

    [Test]
    [TestCase("scenario_0")]
    public void TestParamsCalculator(string testFileKey)
    {
        var testData = LoadTest(testFileKey);
        
        var calculator = new CalculatorExpression();

        foreach (var expression in testData.expressions)
        {
            calculator.SetExpression(expression.key, expression.value);
        }

        foreach (var expressionCase in testData.expected)
        {
            var result = calculator.Get(expressionCase.key);
            Assert.AreEqual(expressionCase.result, result);
        }
    }

    [Test]
    [TestCase("scenario_0")]
    public void TestPerfParamsCalculator(string testFileKey)
    {
        var testData = LoadTest(testFileKey);
        
        var calculator = new CalculatorExpression();

        foreach (var expression in testData.expressions)
        {
            calculator.SetExpression(expression.key, expression.value);
        }

        foreach (var expressionCase in testData.expected)
        {
            Assert.That(() =>
            {
                var result = calculator.Get(expressionCase.key);
            }, Is.Not.AllocatingGCMemory());
        }
    }
    
    private TestExpression LoadTest(string testFileKey)
    {
        var testPath = string.Format(PathTestCase, testFileKey);
        var testText = File.ReadAllText(testPath);
        TestExpression testData = JsonUtility.FromJson<TestExpression>(testText);
        return testData;
    }
    
}
