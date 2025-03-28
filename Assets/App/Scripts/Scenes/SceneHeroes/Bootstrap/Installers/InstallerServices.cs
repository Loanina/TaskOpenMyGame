using System.Collections.Generic;
using App.Scripts.Features.FieldSizeProvider;
using App.Scripts.Modules.Factory;
using App.Scripts.Modules.SceneContainer.Installer;
using App.Scripts.Scenes.SceneHeroes.Features.GameInput.Services;
using App.Scripts.Scenes.SceneHeroes.Features.GameInput.Services.Handlers;
using App.Scripts.Scenes.SceneHeroes.Features.Grid;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.LevelInfo;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.LevelInfo.Serializable;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.LevelInfo.Services.LevelProvider;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.Obstacles.ObstacleMap;
using App.Scripts.Scenes.SceneHeroes.Features.PathFinding;
using App.Scripts.Scenes.SceneHeroes.Features.Units;
using App.Scripts.Scenes.SceneHeroes.Features.Units.Factory;
using UnityEngine;

namespace App.Scripts.Scenes.SceneHeroes.Bootstrap.Installers
{
    public class InstallerServices : MonoInstaller
    {
        [SerializeField]
        private List<ScriptableLevelGridInfo> levels = new();

        [SerializeField] private ServiceLevelProviderJson.Config config;
        
        [SerializeField] private Camera gameCamera;
        
        protected override void OnInstallBindings()
        {
            Container.SetService<IServiceLevelProvider, ServiceLevelProviderJson>(new ServiceLevelProviderJson(config));
           // Container.SetService<IServiceLevelProvider, ServiceLevelProviderConfig>(new ServiceLevelProviderConfig(levels));
            Container.SetService<IFieldSizeProvider, FieldSizeProviderCamera>(new FieldSizeProviderCamera(gameCamera));
            
            Container.SetService<IObstacleMap, ObstacleMapGrid>(Container.CreateInstance<ObstacleMapGrid>());
            Container.SetService<IFactory<IUnitInfo, Unit>, FactoryUnit>(Container.CreateInstance<FactoryUnit>());
            
            Container.SetService<IServiceUnitNavigator, ServiceUnitNavigator>(new ServiceUnitNavigator());
            
            InstallHandlerClick();
        }

        private void InstallHandlerClick()
        {
            var handlerClickContainer = new HandlerInputCellClickContainer();
            
            handlerClickContainer.AddHandler(InputHandlersKeys.HeroMove, new HandlerMoveHero());
            handlerClickContainer.AddHandler(InputHandlersKeys.ChangeObstacle, Container.CreateInstance<HandlerUpdateObstacle>());
            handlerClickContainer.AddHandler(InputHandlersKeys.FindPath, Container.CreateInstance<HandlerFindPath>());
            
            Container.SetService<IHandlerFieldClick, HandlerInputCellClickContainer>(handlerClickContainer);
            Container.SetService<IHandlerInputSelector, HandlerInputCellClickContainer>(handlerClickContainer);

        }
    }
}