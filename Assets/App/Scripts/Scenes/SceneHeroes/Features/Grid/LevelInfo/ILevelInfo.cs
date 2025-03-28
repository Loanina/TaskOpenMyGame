using System.Collections.Generic;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.LevelInfo.Config;
using UnityEngine;

namespace App.Scripts.Scenes.SceneHeroes.Features.Grid.LevelInfo
{
    public interface ILevelInfo
    {
        Vector2Int Size { get; }
        
        IEnumerable<ICellObstacle> Obstacles { get; } 
        
        IUnitInfo Unit { get; }
    }

    public interface ICellObstacle
    {
        Vector2Int CellPosition { get; }
        int Obstacle { get; }
    }
    
    public interface IUnitInfo
    {
        Vector2Int CellPosition { get; }
        UnitType Unit { get; }
    }
}