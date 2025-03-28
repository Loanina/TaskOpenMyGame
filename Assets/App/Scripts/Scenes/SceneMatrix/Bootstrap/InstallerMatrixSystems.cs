using App.Scripts.Features.LevelSelection;
using App.Scripts.Modules.SceneContainer.Installer;
using App.Scripts.Modules.Systems;
using App.Scripts.Scenes.SceneMatrix.Features.FieldInteractions.Systems;
using App.Scripts.Scenes.SceneMatrix.Features.FigureSwitcher;
using App.Scripts.Scenes.SceneMatrix.Features.Grid.Systems;
using App.Scripts.Scenes.SceneMatrix.Features.Scores.Systems;
using UnityEngine;

namespace App.Scripts.Scenes.SceneMatrix.Bootstrap
{
    public class InstallerMatrixSystems : MonoInstaller
    {
        [SerializeField] private ViewSwitchNavigator levelSwitcher;
        
        protected override void OnInstallBindings()
        {
            var systemGroup = new SystemsGroup();
            
            systemGroup.AddSystem(Container.CreateInstance<SystemResetField>());
            systemGroup.AddSystem(Container.CreateInstance<SystemRebuildField>());
            systemGroup.AddSystem(Container.CreateInstanceWithArguments<SystemSwitchLevel>(levelSwitcher));
            systemGroup.AddSystem(Container.CreateInstance<SystemProcessPackFigures>());
            systemGroup.AddSystem(Container.CreateInstance<SystemUpdateViewFieldState>());
            systemGroup.AddSystem(Container.CreateInstance<SystemUpdateScores>());
            systemGroup.AddSystem(Container.CreateInstance<SystemUpdateScoreView>());
            
            Container.SetServiceSelf(systemGroup);
        }
    }
}