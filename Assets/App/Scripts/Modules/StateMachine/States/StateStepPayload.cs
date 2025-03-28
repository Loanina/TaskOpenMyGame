using System.Threading.Tasks;

namespace App.Scripts.Modules.StateMachine.States
{
    public abstract class StateStepPayload<T> : StateStep, IStateStepPayload<T>
    {
        public virtual Task OnEnter(T value)
        {
            return Task.CompletedTask;
        }
    }
}