using UnityEngine;

namespace App.Scripts.Scenes.SceneHeroes.Features.Grid.LevelInfo.Serializable
{
    public struct Place
    {
        public int X;
        public int Y;
        
        public Place(Vector2Int pos)
        {
            X = pos.x;
            Y = pos.y;
        }

        public Place(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Vector2Int ToVector2Int()
        {
            return new Vector2Int(X, Y);
        }
        
    }
}