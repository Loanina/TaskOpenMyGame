using App.Scripts.Modules.Systems;
using App.Scripts.Scenes.SceneHeroes.Features.GameInput.Services;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.Components;

namespace App.Scripts.Scenes.SceneHeroes.Features.GameInput.Systems
{
    public class SystemResetInput : ISystem
    {
        private readonly IHandlerInputSelector _handlerInputSelector;
        public SystemContext Context { get; set; }

        public SystemResetInput(IHandlerInputSelector handlerInputSelector)
        {
            _handlerInputSelector = handlerInputSelector;
        }
        
        public void Init()
        {
        }

        public void Update(float dt)
        {
            if (Context.Signals.HasComponent<ComponentRequestRebuildLevel>())
            {
                _handlerInputSelector.Reset();
            }
        }

        public void Cleanup()
        {
        }
    }
}