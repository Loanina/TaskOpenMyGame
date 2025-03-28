using App.Scripts.Features.GridField.GridContainer;
using App.Scripts.Modules.Factory;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.LevelInfo.Config;

namespace App.Scripts.Scenes.SceneHeroes.Features.Units.Factory
{
    public class FactoryViewUnit : IFactory<UnitType, ViewCell>
    {
        private readonly FactoryViewCell _factoryViewCell;
        private readonly ConfigUnitViews _configUnitViews;

        public FactoryViewUnit(FactoryViewCell factoryViewCell, ConfigUnitViews configUnitViews)
        {
            _factoryViewCell = factoryViewCell;
            _configUnitViews = configUnitViews;
        }
        
        public ViewCell Create(UnitType param)
        {
            var configUnit = _configUnitViews.FindConfig(param);
            
            var cell = _factoryViewCell.Create(_configUnitViews.Layer, configUnit.view);

            return cell;
        }
    }
}