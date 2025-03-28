using App.Scripts.Features.LevelSelection;
using App.Scripts.Modules.Systems;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.Components;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.LevelInfo.Services.LevelProvider;
using App.Scripts.Scenes.SceneHeroes.Features.LevelNavigation.Components;

namespace App.Scripts.Scenes.SceneHeroes.Features.LevelNavigation.Systems
{
    public class SystemRequestUpdateLevel : ISystem
    {
        private readonly IServiceLevelProvider _serviceLevelProvider;
        private readonly IViewSwitchNavigator _viewSwitchNavigator;
        public SystemContext Context { get; set; }

        public SystemRequestUpdateLevel(IServiceLevelProvider serviceLevelProvider, IViewSwitchNavigator viewSwitchNavigator)
        {
            _serviceLevelProvider = serviceLevelProvider;
            _viewSwitchNavigator = viewSwitchNavigator;
        }
        
        public void Init()
        {
            var componentLevelIndex = new ComponentLevelIndex();
            Context.Data.SetComponent(componentLevelIndex);
            GenerateRequest(componentLevelIndex);
            
            _viewSwitchNavigator.ChangeLevel += OnChangeSwitch;
        }

        private void OnChangeSwitch(int index)
        {
            Context.Signals.AddComponent(new RequestUpdateLevelIndex(index));
        }

        public void Update(float dt)
        {
            if (!Context.Signals.HasComponent<RequestUpdateLevelIndex>())
            {
                return;
            }
            
            var levelIndex = Context.Data.GetComponent<ComponentLevelIndex>();

            int nextLevelIndex = levelIndex.Index;
            
            foreach (var requestUpdate in Context.Signals.GetComponents<RequestUpdateLevelIndex>())
            {
                nextLevelIndex += requestUpdate.ChangeIndex;
            }

            if (nextLevelIndex < 0)
            {
                nextLevelIndex = 0;
            }

            if (nextLevelIndex >= _serviceLevelProvider.LevelCount())
            {
                nextLevelIndex = 0;
            }
            
            if (nextLevelIndex == levelIndex.Index)
            {
                return;
            }
            
            levelIndex.Index = nextLevelIndex;

            GenerateRequest(levelIndex);
        }
        
        private void GenerateRequest(ComponentLevelIndex componentLevelIndex)
        {
            var levelInfo = _serviceLevelProvider.GetLevel(componentLevelIndex.Index);
            
            Context.Signals.AddComponent(new ComponentRequestRebuildLevel(levelInfo));
        }

        public void Cleanup()
        {
            _viewSwitchNavigator.ChangeLevel -= OnChangeSwitch;
        }
    }
}