using UnityEngine;

namespace App.Scripts.Scenes.SceneHeroes.Features.PathFinding.PathLineDrawer
{
    public interface IPathLineDrawer
    {
        void AddPoint(Vector2 point);
        
        void Reset();
    }
}