using System.Threading.Tasks;
using App.Scripts.Features.Scenes.SceneNavigation;
using App.Scripts.Features.Scenes.SceneSelector.Triggers;
using App.Scripts.Modules.StateMachine.States;

namespace App.Scripts.Features.Scenes.SceneSelector.StateSteps
{
    public class StepChangeScene : StateStepPayload<TriggerSceneChange>
    {
        private readonly ISceneNavigator _sceneNavigator;

        public StepChangeScene(ISceneNavigator sceneNavigator)
        {
            _sceneNavigator = sceneNavigator;
        }
        
        public override Task OnEnter(TriggerSceneChange value)
        {
            _sceneNavigator.LoadScene(value.SceneInfo);
            
            return base.OnEnter(value);
        }
    }
}