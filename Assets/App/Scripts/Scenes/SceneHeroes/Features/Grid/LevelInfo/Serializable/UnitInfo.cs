using System;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.LevelInfo.Config;
using UnityEngine;

namespace App.Scripts.Scenes.SceneHeroes.Features.Grid.LevelInfo.Serializable
{
    [Serializable]
    public class UnitInfo : IUnitInfo
    {
        [SerializeField]
        private Vector2Int cellPosition;

        [SerializeField]
        private UnitType unit;
        
        public Vector2Int CellPosition => cellPosition;
        public UnitType Unit => unit;

        public UnitInfo()
        {
        }

        public UnitInfo(UnitType unitType, Vector2Int cell)
        {
            unit = unitType;
            cellPosition = cell;
        }
    }
}