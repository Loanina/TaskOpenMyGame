using App.Scripts.Modules.CommandButton;
using App.Scripts.Modules.Systems;
using App.Scripts.Scenes.SceneMatrix.Features.FieldInteractions.Signal;

namespace App.Scripts.Scenes.SceneMatrix.Features.FieldInteractions.Commands
{
    public class CommandResetField : ICommandButton
    {
        private readonly SystemsGroup _systemsGroup;

        public CommandResetField(SystemsGroup systemsGroup)
        {
            _systemsGroup = systemsGroup;
        }
        
        public void Execute()
        {
            _systemsGroup.Context.Signals.SetComponent(new SignalResetField());
        }
    }
}