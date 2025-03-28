using System.Collections.Generic;
using App.Scripts.Features.GridField.GridContainer;
using App.Scripts.Scenes.SceneHeroes.Features.Grid;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.LevelInfo.Config;
using UnityEngine;

namespace App.Scripts.Scenes.SceneHeroes.Features.Units
{
    public class Unit 
    {
        private readonly ViewCell _viewCell;

        public Vector2Int CellPosition { get; private set; }
        public UnitType UnitType { get; }
        
        public Unit(UnitType unitType, Vector2Int cellPosition, ViewCell viewCell)
        {
            UnitType = unitType;
            CellPosition = cellPosition;
            _viewCell = viewCell;
        }

        public void PlaceAt(Vector2Int unitCellPosition)
        {
            _viewCell.SetGridPosition(unitCellPosition);
            CellPosition = unitCellPosition;
        }

        public void Cleanup()
        {
            _viewCell.Remove();
        }
    }
}