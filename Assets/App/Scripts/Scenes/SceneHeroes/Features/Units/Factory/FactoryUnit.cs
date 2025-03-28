using App.Scripts.Features.GridField.GridContainer;
using App.Scripts.Modules.Factory;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.LevelInfo;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.LevelInfo.Config;

namespace App.Scripts.Scenes.SceneHeroes.Features.Units.Factory
{
    public class FactoryUnit : IFactory<IUnitInfo, Unit>
    {
        private readonly IViewGridContainer _viewGridContainer;
        private readonly IFactory<UnitType, ViewCell> _factoryViewUnit;

        public FactoryUnit(IViewGridContainer viewGridContainer,
            IFactory<UnitType, ViewCell> factoryViewUnit)
        {
            _viewGridContainer = viewGridContainer;
            _factoryViewUnit = factoryViewUnit;
        }

        public Unit Create(IUnitInfo unitInfo)
        {
            var unitView = _factoryViewUnit.Create(unitInfo.Unit);
            _viewGridContainer.AddViewCell(unitView, unitInfo.CellPosition);
            var unit = new Unit(unitInfo.Unit, unitInfo.CellPosition, unitView);
            return unit;
        }
    }
}