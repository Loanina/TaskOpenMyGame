namespace App.Scripts.Modules.StateMachine.Transitions
{
    public interface ITransitionTrigger<T> : ITransition
    {
        void Trigger(T triggerData);
    }
}