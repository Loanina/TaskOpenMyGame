using System;
using System.IO;
using App.Scripts.Modules.Systems;
using App.Scripts.Scenes.SceneHeroes.Features.Grid;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.LevelInfo.Config;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.LevelInfo.Serializable;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.Obstacles.ObstacleMap;
using App.Scripts.Scenes.SceneHeroes.Features.Units;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Scenes.SceneHeroes.Features.SaveField
{
    public class SystemSaveField : ISystem
    {
        private readonly Button _buttonSave;
        private readonly IServiceSaveField _serviceSaveField;
        private readonly IObstacleMap _obstacleMap;
        public SystemContext Context { get; set; }

        public SystemSaveField(Button buttonSave, IServiceSaveField serviceSaveField, IObstacleMap obstacleMap)
        {
            _buttonSave = buttonSave;
            _serviceSaveField = serviceSaveField;
            _obstacleMap = obstacleMap;
        }
        
        public void Init()
        {
            _buttonSave.onClick.AddListener(ProcessFieldSave);
        }

        private void ProcessFieldSave()
        {
            LevelInfoTarget fieldModel = BuildLevelModel();
            _serviceSaveField.SaveField(fieldModel);
        }

        private LevelInfoTarget BuildLevelModel()
        {
            var fieldModel = new LevelInfoTarget();

            var obstacles = _obstacleMap.ObstacleMap;
            var unit = Context.Data.GetComponent<Unit>();
            fieldModel.gridSize = new Place(obstacles.Size);

            fieldModel.PlaceUnit = new Place(unit.CellPosition);
            fieldModel.UnitType = unit.UnitType;

            for (int i = 0; i < obstacles.Height; i++)
            {
                for (int j = 0; j < obstacles.Width; j++)
                {
                    var obstacleType = _obstacleMap.ObstacleMap[j, i];
                    if (obstacleType != ObstacleType.None)
                    {
                        fieldModel.Obstacles.Add(new ObstacleSerializable
                        {
                            Place = new Place(j, i),
                            ObstacleType = obstacleType
                        });
                    }
                }
            }

            return fieldModel;
        }

        public void Update(float dt)
        {
        }

        public void Cleanup()
        {
            _buttonSave.onClick.RemoveListener(ProcessFieldSave);
        }
        
    }
}