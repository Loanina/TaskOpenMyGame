using App.Scripts.Modules.CommandButton;
using App.Scripts.Modules.Systems;
using App.Scripts.Scenes.SceneMatrix.Features.FieldInteractions.Signal;

namespace App.Scripts.Scenes.SceneMatrix.Features.FieldInteractions.Commands
{
    public class CommandPackFigures : ICommandButton
    {
        private readonly SystemsGroup _group;

        public CommandPackFigures(SystemsGroup group)
        {
            _group = group;
        }
        
        public void Execute()
        {
            _group.Context.Signals.SetComponent(new SignalPackField());
        }
    }
}