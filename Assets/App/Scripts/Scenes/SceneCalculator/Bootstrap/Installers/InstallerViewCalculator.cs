using App.Scripts.Modules.SceneContainer.Installer;
using App.Scripts.Scenes.SceneCalculator.Features.ViewLog;
using UnityEngine;

namespace App.Scripts.Scenes.SceneCalculator.Bootstrap.Installers
{
    public class InstallerViewCalculator : MonoInstaller
    {
        [SerializeField] private ViewLogMono viewLog;
        
        protected override void OnInstallBindings()
        {
            Container.SetService<IViewLog, ViewLogMono>(viewLog);
        }
    }
}