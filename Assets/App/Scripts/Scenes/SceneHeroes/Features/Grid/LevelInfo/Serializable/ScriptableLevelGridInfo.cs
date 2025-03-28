using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.Scenes.SceneHeroes.Features.Grid.LevelInfo.Serializable
{
    [CreateAssetMenu(fileName = "levelGridInfo", menuName = "app/heroes/level info")]
    public class ScriptableLevelGridInfo : ScriptableObject, ILevelInfo
    {
        [SerializeField] public Vector2Int size;
        [SerializeField] public List<CellObstacle> obstacles = new ();
        [SerializeField] public UnitInfo unitInfo;


        
        public Vector2Int Size => size;
        public IEnumerable<ICellObstacle> Obstacles => obstacles;
        public IUnitInfo Unit => unitInfo;

    }
}