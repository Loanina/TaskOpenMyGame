using App.Scripts.Modules.SceneContainer.Installer;
using App.Scripts.Modules.StateMachine;

namespace App.Scripts.Features.CoreGame
{
    public class ControllerStateMachine : IInitializable, IUpdatable
    {
        private readonly IStateMachine _stateMachine;

        public ControllerStateMachine(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public void Init()
        {
            _stateMachine.Initialize();
        }

        public void Update()
        {
            _stateMachine.Update();
        }
    }
}