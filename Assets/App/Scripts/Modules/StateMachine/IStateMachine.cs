namespace App.Scripts.Modules.StateMachine
{
    public interface IStateMachine : IStateMachineTrigger
    {
        void Initialize();
        void Update();
    }
}