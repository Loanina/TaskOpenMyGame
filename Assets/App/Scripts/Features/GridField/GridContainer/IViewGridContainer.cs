using UnityEngine;

namespace App.Scripts.Features.GridField.GridContainer
{
    public interface IViewGridContainer
    {
        void UpdateGrid(Vector2Int size);
        void SetupFieldSize(Rect fieldRect);
        void AddViewCell(ViewCell viewCell, Vector2Int position);
        Vector2 GridToPosition(Vector2Int cell);
        Vector2Int GetCellByPos(Vector3 worldClick);
        void RemoveView(ViewCell viewCell);

        void ClearCells();
    }
}