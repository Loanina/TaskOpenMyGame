using System.Threading.Tasks;
using App.Scripts.Features.Scenes.SceneNavigation;
using App.Scripts.Features.Scenes.SceneNavigation.Config;
using App.Scripts.Features.Scenes.SceneSelector.Triggers;
using App.Scripts.Features.Scenes.SceneSelector.View.ControlPanel;
using App.Scripts.Features.Scenes.SceneSelector.View.ViewSwitcher;
using App.Scripts.Modules.StateMachine.States;

namespace App.Scripts.Features.Scenes.SceneSelector.StateSteps
{
    public class StepControlSceneSelection : StateStep
    {
        private readonly IViewSceneSwitcher _viewSceneSwitcher;
        private readonly ISceneNavigator _sceneNavigator;
        private readonly IControlPanel _controlPanel;

        public StepControlSceneSelection(IViewSceneSwitcher viewSceneSwitcher, ISceneNavigator sceneNavigator, IControlPanel controlPanel)
        {
            _viewSceneSwitcher = viewSceneSwitcher;
            _sceneNavigator = sceneNavigator;
            _controlPanel = controlPanel;
        }
        
        public override Task OnEnter()
        {
            _viewSceneSwitcher.Hide();
            
            _viewSceneSwitcher.OnItemSelected += OnItemSelected;
            _controlPanel.OnScenePanelClick += SceneSelectionClick;
            UpdateItems();
            return base.OnEnter();
        }

        private void SceneSelectionClick()
        {
            if (_viewSceneSwitcher.IsShow)
            {
                _viewSceneSwitcher.Hide();
                return;
            }

            _viewSceneSwitcher.Show();
        }

        private void UpdateItems()
        {
            _viewSceneSwitcher.UpdateItems(_sceneNavigator.GetAvailableSwitchScenes());
        }
        
        private void OnItemSelected(SceneInfo sceneInfo)
        {
            StateMachine.FireTrigger(new TriggerSceneChange(sceneInfo));
        }

        public override async Task OnExit()
        {
            _viewSceneSwitcher.OnItemSelected -= OnItemSelected;
            _controlPanel.OnScenePanelClick -= SceneSelectionClick;

            await _viewSceneSwitcher.Hide();
        }
    }
}