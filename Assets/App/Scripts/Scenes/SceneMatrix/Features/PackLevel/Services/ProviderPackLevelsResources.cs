using System;
using App.Scripts.Scenes.SceneMatrix.Features.FigureProvider;
using App.Scripts.Scenes.SceneMatrix.Features.PackLevel.Model;
using UnityEngine;

namespace App.Scripts.Scenes.SceneMatrix.Features.PackLevel.Services
{
    public class ProviderPackLevelsResources : IProviderPackLevels
    {
        private readonly SettingsLoadPackLevels _settings;
        private readonly IFigureProvider _figureProvider;
        private TextAsset[] _levelsTxts;
        public ProviderPackLevelsResources(SettingsLoadPackLevels settings, IFigureProvider figureProvider)
        {
            _settings = settings;
            _figureProvider = figureProvider;

            Preload();
        }

        private void Preload()
        {
            _levelsTxts = Resources.LoadAll<TextAsset>(_settings.loadPath);
        }

        public int GetAvailableLevelCount()
        {
            return _levelsTxts.Length;
        }

        public PackLevelData LoadLevel(int id)
        {
            if (id < 0 || id > _levelsTxts.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            try
            {
                var packData = JsonUtility.FromJson<PackLevelJson>(_levelsTxts[id].text);
                var level = new PackLevelData(packData.width, packData.height);

                foreach (var figureId in packData.figuresIds)
                {
                    var figure = _figureProvider.GetFigure(figureId);
                    level.Figures.Add(figure);
                }
                
                return level;
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }

            return null;
        }
    }
}