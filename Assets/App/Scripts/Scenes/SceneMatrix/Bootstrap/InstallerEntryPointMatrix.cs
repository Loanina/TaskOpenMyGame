using App.Scripts.Features.CoreGame;
using App.Scripts.Features.GridField.GridContainer.Step;
using App.Scripts.Modules.StateMachine;

namespace App.Scripts.Scenes.SceneMatrix.Bootstrap
{
    public class InstallerEntryPointMatrix : InstallerSimpleStateMachine
    {
        protected override void OnCompleteBuildGraph(GraphStates graphStates)
        {
            var initState = GetNode(graphStates, KeyGameStates.Initialize);
            initState.AddStep(Container.CreateInstance<StepInitializeGridView>());
        }
    }
}