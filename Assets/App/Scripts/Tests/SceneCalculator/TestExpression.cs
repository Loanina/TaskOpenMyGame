using System;
using System.Collections.Generic;

namespace Tests.App.Scripts.Tests.SceneCalculator
{
    [Serializable]
    public class TestExpression
    {
        public List<TestParamExpression> expressions;
        public List<TestExpressionCase> expected;
    }

    [Serializable]
    public class TestParamExpression
    {
        public string key;
        public string value;
    }
    [Serializable]
    public class TestExpressionCase
    {
        public string key;
        public int result;
    }
}