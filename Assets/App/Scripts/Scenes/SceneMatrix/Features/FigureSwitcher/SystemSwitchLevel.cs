using System;
using App.Scripts.Features.LevelSelection;
using App.Scripts.Modules.Systems;
using App.Scripts.Scenes.SceneMatrix.Features.Grid.Signals;
using App.Scripts.Scenes.SceneMatrix.Features.PackLevel.Services;

namespace App.Scripts.Scenes.SceneMatrix.Features.FigureSwitcher
{
    public class SystemSwitchLevel : ISystem
    {
        private readonly IProviderPackLevels _levelProvider;
        private readonly IViewSwitchNavigator _viewSwitchNavigator;
        public SystemContext Context { get; set; }

        public SystemSwitchLevel(IProviderPackLevels levelProvider, IViewSwitchNavigator viewSwitchNavigator)
        {
            _levelProvider = levelProvider;
            _viewSwitchNavigator = viewSwitchNavigator;
        }
        
        public void Init()
        {
            _viewSwitchNavigator.ChangeLevel += SwitchSwitch;
            Context.Data.SetComponent(new ComponentCurrentLevel());
            SetupFigure(0);
        }

        private void SwitchSwitch(int index)
        {
            var currentFigure = Context.Data.GetComponent<ComponentCurrentLevel>();
            var nextIndex = currentFigure.Index + index;

            int totalCount = _levelProvider.GetAvailableLevelCount();
            
            if (nextIndex >= totalCount)
            {
                nextIndex = 0;
            }

            if (nextIndex < 0)
            {
                nextIndex = totalCount - 1;
            }

            currentFigure.Index = nextIndex;

            SetupFigure(currentFigure.Index);
        }

        private void SetupFigure(int index)
        {
            var level = _levelProvider.LoadLevel(index);
            if (level is null)
            {
                throw new Exception($"cant load level at {index}");
            }
            
            var currentFigure = Context.Data.GetComponent<ComponentCurrentLevel>();
            currentFigure.LevelData = level;
            
            Context.Signals.SetComponent(new RequestUpdateLevel());
        }

        public void Update(float dt)
        {
            
        }

        public void Cleanup()
        {
            _viewSwitchNavigator.ChangeLevel -= SwitchSwitch;
        }
    }
}