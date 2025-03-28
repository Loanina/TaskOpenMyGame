using System.Collections.Generic;
using App.Scripts.Modules.GridModel;
using UnityEngine;

namespace App.Scripts.Scenes.SceneMatrix.Features.PackLevel.Model
{
    public class PackLevelData
    {
        public List<Grid<bool>> Figures = new List<Grid<bool>>();
        public Vector2Int FieldSize { get; }

        public PackLevelData(int width, int height)
        {
            FieldSize = new Vector2Int(width, height);
        }
    }
}