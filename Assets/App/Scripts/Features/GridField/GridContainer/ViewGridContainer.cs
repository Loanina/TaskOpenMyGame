using System;
using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.Features.GridField.GridContainer
{
    public class ViewGridContainer : MonoBehaviour, IViewGridContainer
    {
        [SerializeField] private Transform container;
        
         private Rect fieldRect;

         private readonly List<ViewCell> _cells = new ();
         private float _cellWidth;
         private Vector2Int _cellsSize;
         private Vector2 _placeOffset;
         private Vector2 _cellSize;

         public void SetupFieldSize(Rect rect)
         {
             fieldRect = rect;
         }
         
         public void UpdateGrid(Vector2Int size)
         {
            ClearCells();

            _cellsSize = size;
            var fieldSize = fieldRect.size;
            _cellWidth = Math.Min(fieldRect.size.x / size.x, fieldRect.size.y / size.y);
            _cellSize = new Vector2(_cellWidth, _cellWidth);
            _placeOffset = fieldRect.position + (fieldSize - _cellSize * size) * 0.5f;
         }
         
         public void AddViewCell(ViewCell viewCell, Vector2Int position)
         {
             if (_cells.Contains(viewCell))
             {
                 return;
             }
             
             viewCell.transform.SetParent(container);
             viewCell.OnSetupGridContainer(this);
             viewCell.SetGridPosition(position);
             viewCell.SetSize(_cellWidth);
            _cells.Add(viewCell);
         }

         public Vector2 GridToPosition(Vector2Int cell)
         {
             float halfCellWidth = _cellWidth * 0.5f;
             return new Vector2(cell.x * _cellWidth + halfCellWidth, cell.y * _cellWidth + halfCellWidth) + _placeOffset;
         }

         public Vector2Int GetCellByPos(Vector3 worldPosition)
         {
             Vector2 deltaCell = ((Vector2) worldPosition - _placeOffset) / _cellWidth;
             if (deltaCell.x < 0 || deltaCell.y < 0)
             {
                 return new Vector2Int(-1, -1);
             }
             
             return new Vector2Int((int) deltaCell.x , (int) deltaCell.y);
         }

         public void RemoveView(ViewCell viewCell)
         {
             var removeIndex = _cells.IndexOf(viewCell);
             if (removeIndex > 0)
             {
                 _cells.RemoveAt(removeIndex);
             }
         }

         public void ClearCells()
        {
            for (int i = _cells.Count -1; i >= 0; i--)
            {
                _cells[i].Remove();
            }
            
            _cells.Clear();
        }

    }
}