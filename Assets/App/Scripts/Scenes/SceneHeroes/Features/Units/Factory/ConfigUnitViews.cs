using System;
using System.Collections.Generic;
using System.Linq;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.LevelInfo.Config;
using UnityEngine;

namespace App.Scripts.Scenes.SceneHeroes.Features.Units.Factory
{
    [CreateAssetMenu(menuName = "app/heroes/unit views", fileName = "configViewHeroes")]
    public class ConfigUnitViews : ScriptableObject
    {
        [SerializeField] private List<ConfigUnitView> config = new();
        [SerializeField] 
        private float layer = 1;

        public float Layer => layer;
        
        public ConfigUnitView FindConfig(UnitType unitType)
        {
            return config.FirstOrDefault(x => x.id == unitType);
        }
    }

    [Serializable]
    public class ConfigUnitView
    {
        public Sprite view;
        public UnitType id;
    }
}