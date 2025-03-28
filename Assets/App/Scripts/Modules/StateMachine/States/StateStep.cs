using System.Threading.Tasks;

namespace App.Scripts.Modules.StateMachine.States
{
    public abstract class StateStep : IStateStep
    {
        public virtual void Update()
        {
        }

        public bool IsComplete { get; set; }
        public IStateMachineTrigger StateMachine { get; set; }

        public virtual Task OnExit()
        {
            return Task.CompletedTask;
        }

        public virtual Task OnEnter()
        {
            return Task.CompletedTask;
        }

        protected void CompleteStep()
        {
            IsComplete = true;
        }
    }
}