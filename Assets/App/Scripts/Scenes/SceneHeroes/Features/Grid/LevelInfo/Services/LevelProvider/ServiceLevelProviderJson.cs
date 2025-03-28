using System;
using System.Collections.Generic;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.LevelInfo.Serializable;
using Newtonsoft.Json;
using UnityEngine;

namespace App.Scripts.Scenes.SceneHeroes.Features.Grid.LevelInfo.Services.LevelProvider
{
    public class ServiceLevelProviderJson : IServiceLevelProvider
    {
        private readonly Config _config;

        public ServiceLevelProviderJson(Config config)
        {
            _config = config;
        }
        
        public ILevelInfo GetLevel(int index)
        {
            var levelData =_config.levels[index];

            try
            {
                var levelInfoTarget = JsonConvert.DeserializeObject<LevelInfoTarget>(levelData.text);

                if (levelInfoTarget is null)
                {
                    return null;
                }
                
                var unitInfo = new UnitInfo(levelInfoTarget.UnitType, levelInfoTarget.PlaceUnit.ToVector2Int());

                return new LevelGridInfo(levelInfoTarget.gridSize.ToVector2Int(), levelInfoTarget.Obstacles, unitInfo);
            }
            catch (Exception)
            {
                // ignored
            }

            return null;
        }

        public int LevelCount()
        {
            return _config.levels.Count;
        }
        
        [Serializable]
        public class Config
        {
            public List<TextAsset> levels;
        }
    }
}