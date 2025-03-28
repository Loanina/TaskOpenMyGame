using App.Scripts.Modules.GridModel;
using App.Scripts.Scenes.SceneMatrix.Features.PackLevel.Model;
using UnityEngine;

namespace App.Scripts.Scenes.SceneMatrix.Features.PackLevel.Component
{
    public class ComponentField
    {
        public Grid<CellModel> Grid;

        public ComponentField(Vector2Int size)
        {
            Grid = new Grid<CellModel>(size);
        }
    }
}