using System.Threading.Tasks;
using App.Scripts.Features.Scenes.SceneSelector.Triggers;
using App.Scripts.Modules.StateMachine;
using App.Scripts.Modules.StateMachine.States;
using App.Scripts.Modules.StateMachine.Transitions;

namespace App.Scripts.Features.Scenes.SceneSelector.Transitions
{
    public class TransitionChangeScene : TransitionNavigate, ITransitionTrigger<TriggerSceneChange>
    {
        private TriggerSceneChange _triggerData;

        public void Trigger(TriggerSceneChange triggerData)
        {
            _triggerData = triggerData;
        }

        public override bool CanTransit(IState currentState)
        {
            return _triggerData != null;
        }

        public override Task ProcessEnter(IState currentState)
        {
            var taskEnter = currentState.OnEnter(_triggerData);
            _triggerData = null;
            return taskEnter;
        }
    }
}