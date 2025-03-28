using System;
using System.Collections.Generic;
using System.Linq;
using App.Scripts.Modules.Factory;
using App.Scripts.Modules.Systems;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.Components;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.LevelInfo;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.LevelInfo.Config;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.LevelInfo.Serializable;
using App.Scripts.Scenes.SceneHeroes.Features.Units.UnitSelection.UnitTypeSelector;

namespace App.Scripts.Scenes.SceneHeroes.Features.Units.UnitSelection.Systems
{
    public class SystemSwitchUnit : ISystem
    {
        private readonly IViewSelectorItem _viewSelectorItem;
        private readonly IFactory<IUnitInfo, Unit> _factoryUnit;
        private readonly List<UnitType> _availableUnits;
        public SystemContext Context { get; set; }

        public SystemSwitchUnit(IViewSelectorItem viewSelectorItem, IFactory<IUnitInfo, Unit> factoryUnit)
        {
            _viewSelectorItem = viewSelectorItem;
            _factoryUnit = factoryUnit;

            _availableUnits = GetAvailableItems();
        }
        
        public void Init()
        {
            _viewSelectorItem.OnSelectItem += OnSelectorUnit;
            _viewSelectorItem.UpdateItems(_availableUnits.Select( x=> x.ToString()).ToList());

        }

        private List<UnitType> GetAvailableItems()
        {
            return Enum.GetValues(typeof(UnitType)).Cast<UnitType>().ToList();
        }

        private void OnSelectorUnit(int selectedIndex)
        {
            var unitType = _availableUnits[selectedIndex];
            
            var unit = GetCurrentUnit();

            if (unit.UnitType == unitType)
            {
                return;
            }

            var replaceUnit = _factoryUnit.Create(new UnitInfo(unitType, unit.CellPosition));
            unit.Cleanup();
            Context.Data.SetComponent(replaceUnit);
        }

        private Unit GetCurrentUnit()
        {
            return Context.Data.GetComponent<Unit>();
        }

        public void Update(float dt)
        {
            if (Context.Signals.HasComponent<ComponentRequestRebuildLevel>() is false)
            {
                return;
            }

            var unit = GetCurrentUnit();
            _viewSelectorItem.SelectItem(_availableUnits.IndexOf(unit.UnitType));
        }

        public void Cleanup()
        {
            _viewSelectorItem.OnSelectItem -= OnSelectorUnit;
        }
    }
}