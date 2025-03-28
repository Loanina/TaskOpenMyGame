using App.Scripts.Modules.CommandButton;
using App.Scripts.Modules.SceneContainer.Installer;
using App.Scripts.Scenes.SceneMatrix.Features.FieldInteractions.Commands;
using UnityEngine;

namespace App.Scripts.Scenes.SceneMatrix.Bootstrap
{
    public class InstallerCommands : MonoInstaller
    {
        [SerializeField] private CommandButton processPack;
        [SerializeField] private CommandButton processReset;
        
        protected override void OnInstallBindings()
        {
            processPack.SetupCommand(Container.CreateInstance<CommandPackFigures>());
            processReset.SetupCommand(Container.CreateInstance<CommandResetField>());
        }
    }
}