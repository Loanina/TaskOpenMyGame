using System;
using System.Collections.Generic;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.LevelInfo.Config;
using UnityEngine;

namespace App.Scripts.Scenes.SceneHeroes.Features.Grid.LevelInfo.Serializable
{
    [Serializable]
    public class LevelInfoTarget
    {
        public Place gridSize;

        public List<ObstacleSerializable> Obstacles = new ();

        public Place PlaceUnit;
        public UnitType UnitType;

        public Place target;

        public int targetStepCount;
    }

    [Serializable]
    public class ObstacleSerializable : ICellObstacle
    {
        public Place Place;
        public int ObstacleType;
        public Vector2Int CellPosition => Place.ToVector2Int();
        public int Obstacle => ObstacleType;
    }

}