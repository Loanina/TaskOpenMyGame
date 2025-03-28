using System.Threading.Tasks;
using App.Scripts.Modules.StateMachine.States;

namespace App.Scripts.Modules.StateMachine.Transitions
{
    public class TransitionNavigate : ITransition
    {
        public string NextNode { get;  set; }
        
        public virtual bool CanTransit(IState currentState)
        {
            return true;
        }

        public virtual Task ProcessEnter(IState currentState)
        {
            return currentState.OnEnter();
        }
    }
}