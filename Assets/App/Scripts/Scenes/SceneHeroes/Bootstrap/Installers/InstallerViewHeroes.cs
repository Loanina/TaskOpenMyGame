using System;
using App.Scripts.Features.GridField.GridContainer;
using App.Scripts.Features.GridField.GridContainer.Step;
using App.Scripts.Features.LevelSelection;
using App.Scripts.Modules.Factory;
using App.Scripts.Modules.SceneContainer.Installer;
using App.Scripts.Scenes.SceneHeroes.Features.Grid;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.LevelInfo.Config;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.Obstacles;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.Obstacles.Config;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.Obstacles.ObstacleView;
using App.Scripts.Scenes.SceneHeroes.Features.PathFinding.PathDrawer;
using App.Scripts.Scenes.SceneHeroes.Features.PathFinding.PathLineDrawer;
using App.Scripts.Scenes.SceneHeroes.Features.Units;
using App.Scripts.Scenes.SceneHeroes.Features.Units.Factory;
using UnityEngine;

namespace App.Scripts.Scenes.SceneHeroes.Bootstrap.Installers
{
    public class InstallerViewHeroes : MonoInstaller
    {
        [SerializeField] private ViewSwitchNavigator viewSwitchNavigator;
        [SerializeField] private ViewGridContainer viewGridContainer;

        [SerializeField] private StepInitializeGridView.Config configField;

        [SerializeField]
        private ViewCellSpriteRender prefabView;
        [SerializeField] private ConfigViewObstacle configViewSpriteCell;
        [SerializeField] private ConfigUnitViews configUnits;
        [SerializeField] private ViewPathGrid.Config pathConfig;

        [SerializeField] private PathLineDrawerMono lineDrawer;
        
        protected override void OnInstallBindings()
        {
            Container.SetService<IViewSwitchNavigator, ViewSwitchNavigator>(viewSwitchNavigator);
            Container.SetService<IViewGridContainer, ViewGridContainer>(viewGridContainer);
            Container.SetServiceSelf(configField);
            
            var factoryViewCell = new FactoryViewCell(prefabView);
            
            Container.SetService<IFactory<ViewCell>, FactoryViewCell>(factoryViewCell);
            Container.SetService<IFactory<int, ViewCell>, FactoryViewObstacle>(new FactoryViewObstacle(configViewSpriteCell, new FactoryViewCell(prefabView)));
            Container.SetService<IFactory<UnitType, ViewCell>, FactoryViewUnit>(new FactoryViewUnit(factoryViewCell, configUnits));
            
            Container.SetService<IObstacleConfiguration, ConfigViewObstacle>(configViewSpriteCell);
            
            Container.SetService<IViewPath, ViewPathGrid>(Container.CreateInstanceWithArguments<ViewPathGrid>(pathConfig, lineDrawer));
        }
    }
}