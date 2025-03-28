using App.Scripts.Features.CoreGame;
using App.Scripts.Features.GridField.GridContainer.Step;
using App.Scripts.Modules.StateMachine;

namespace App.Scripts.Scenes.SceneHeroes.Bootstrap.Installers
{
    public class InstallerEntryPoint : InstallerSimpleStateMachine
    {
        protected override void OnCompleteBuildGraph(GraphStates graphStates)
        {
            var initState = GetNode(graphStates, KeyGameStates.Initialize);
            initState.AddStep(Container.CreateInstance<StepInitializeGridView>());
        }
    }
}