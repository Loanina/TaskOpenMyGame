namespace App.Scripts.Modules.StateMachine
{
    public interface IStateMachineTrigger
    {
        void FireTrigger<T>(T triggerSceneChange);
    }
}