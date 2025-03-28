using UnityEngine;

namespace App.Scripts.Scenes.SceneMatrix.Features.Grid.View
{
    public interface IViewMatrixField
    {
        void Clear();
        void UpdateSize(Vector2Int size);
        void ClearCell(Vector2Int cell);
        void SetCellColor(Vector2Int cell, Color color);
    }
}