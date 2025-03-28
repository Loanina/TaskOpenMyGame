using System.IO;
using App.Scripts.Modules.GridModel;
using App.Scripts.Modules.Serializer;
using App.Scripts.Scenes.SceneHeroes.Features.Grid;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.LevelInfo.Serializable;
using App.Scripts.Scenes.SceneHeroes.Features.PathFinding;
using NUnit.Framework;
using UnityEngine;

public class TestPathFinding
{
    private const string PathTest = "Assets/App/Scripts/Tests/SceneHeroes/TestCases/{0}.json";

    [Test]
    [TestCase("test_field_path(0)")]
    [TestCase("test_field_path(1)")]
    [TestCase("test_field_path(2)")]
    [TestCase("test_field_path(3)")]
    [TestCase("test_field_path(4)")]
    [TestCase("test_field_path(5)")]
    [TestCase("test_field_path(6)")]
    [TestCase("test_field_path(7)")]
    [TestCase("test_field_path(8)")]
    [TestCase("test_field_path(9)")]
    public void TestPathFindingSimplePasses(string testData)
    {
        var serviceUnitNavigator = new ServiceUnitNavigator();
    
        var testCaseText = File.ReadAllText(string.Format(PathTest, testData));

        var serializer = new JsonConverter();
        
        var testCase = serializer.Deserialize<LevelInfoTarget>(testCaseText);
        
        var grid = new Grid<int>(testCase.gridSize.ToVector2Int());

        foreach (var obstacle in testCase.Obstacles)
        {
            grid[obstacle.Place.ToVector2Int()] = obstacle.ObstacleType;
        }
    
        var path = serviceUnitNavigator.FindPath(testCase.UnitType, testCase.PlaceUnit.ToVector2Int(), 
            testCase.target.ToVector2Int(), grid);

        if (testCase.targetStepCount < 0 && path is null)
        {
            return;   
        }

        Assert.AreEqual(testCase.targetStepCount, path.Count,"step count invalid");
    }


}
