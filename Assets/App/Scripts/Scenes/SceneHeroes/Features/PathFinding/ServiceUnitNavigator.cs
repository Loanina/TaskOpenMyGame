using System.Collections.Generic;
using App.Scripts.Modules.GridModel;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.LevelInfo.Config;
using UnityEngine;

namespace App.Scripts.Scenes.SceneHeroes.Features.PathFinding
{
    public class ServiceUnitNavigator : IServiceUnitNavigator
    {
        public List<Vector2Int> FindPath(UnitType unitType, Vector2Int from, Vector2Int to, Grid<int> gridMatrix)
        {
            //implement find path here
            return new List<Vector2Int> { from, to};
        }
    }
}