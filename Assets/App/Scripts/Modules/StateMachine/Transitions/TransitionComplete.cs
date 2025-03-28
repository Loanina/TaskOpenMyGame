using App.Scripts.Modules.StateMachine.States;

namespace App.Scripts.Modules.StateMachine.Transitions
{
    public class TransitionComplete : TransitionNavigate
    {
        public override bool CanTransit(IState currentState)
        {
            return currentState.IsComplete;
        }
    }
}