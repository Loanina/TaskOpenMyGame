using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.Scenes.SceneHeroes.Features.PathFinding.PathDrawer
{
    public interface IViewPath
    {
        void Reset();
        void DrawCellPath(List<Vector2Int> path);
    }
}