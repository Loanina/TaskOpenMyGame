using App.Scripts.Features.Scenes.SceneNavigation;
using App.Scripts.Features.Scenes.SceneNavigation.Config;
using App.Scripts.Features.Scenes.SceneSelector.View.ControlPanel;
using App.Scripts.Features.Scenes.SceneSelector.View.ViewSwitcher;
using App.Scripts.Modules.SceneContainer.Installer;
using UnityEngine;

namespace App.Scripts.Features.Scenes.SceneSelector.Installer
{
    public class InstallerSceneSelection : MonoInstaller
    {
        [SerializeField] private ViewSceneSwitcherMono viewSceneSwitcherMono; 
        [SerializeField] private MonoControlPanel monoControlPanel; 
        [SerializeField] private ConfigScenes configScenes; 
            
        protected override void OnInstallBindings()
        {
            Container.SetService<IViewSceneSwitcher, ViewSceneSwitcherMono>(viewSceneSwitcherMono);
            Container.SetService<IControlPanel, MonoControlPanel>(monoControlPanel);
            Container.SetService<ISceneNavigator, SceneNavigatorLoader>(new SceneNavigatorLoader(configScenes));
        }
    }
}