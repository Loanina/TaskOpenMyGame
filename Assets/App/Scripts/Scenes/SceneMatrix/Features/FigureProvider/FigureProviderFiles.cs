using System;
using System.Collections.Generic;
using App.Scripts.Modules.GridModel;
using App.Scripts.Scenes.SceneMatrix.Features.FigureProvider.Parser;
using App.Scripts.Scenes.SceneMatrix.Features.FigureProvider.ProviderResource;

namespace App.Scripts.Scenes.SceneMatrix.Features.FigureProvider
{
    public class FigureProviderFiles : IFigureProvider
    {
        private readonly Config _config;
        private readonly IFigureParser _parser;
        private readonly IProviderResource _providerResource;
        private List<Grid<bool>> _figures;

        public int TotalFiguresCount => _figures.Count;

        public FigureProviderFiles(Config config, IFigureParser parser, IProviderResource providerResource)
        {
            _config = config;
            _parser = parser;
            _providerResource = providerResource;
            PreLoad();
        }

        private void PreLoad()
        {
            var textAsset = _providerResource.LoadTextResource(_config.pathLevels);
            _figures =  _parser.ParseFile(textAsset);
        }

        public Grid<bool> GetFigure(int index)
        {
            if (index < 0 || index > TotalFiguresCount)
            {
                return null;
            }
            
            return _figures[index];
        }

        
        [Serializable]
        public class Config
        {
            public string pathLevels;
        }
    }
}