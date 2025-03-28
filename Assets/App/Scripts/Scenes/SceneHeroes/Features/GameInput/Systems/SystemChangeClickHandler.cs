using System.Linq;
using App.Scripts.Modules.Systems;
using App.Scripts.Scenes.SceneHeroes.Features.GameInput.Services;
using App.Scripts.Scenes.SceneHeroes.Features.Units.UnitSelection;
using App.Scripts.Scenes.SceneHeroes.Features.Units.UnitSelection.UnitTypeSelector;

namespace App.Scripts.Scenes.SceneHeroes.Features.GameInput.Systems
{
    public class SystemChangeClickHandler : ISystem
    {
        private readonly IHandlerInputSelector _handlerInputSelector;
        private readonly IViewSelectorItem _viewSelectorItem;
        public SystemContext Context { get; set; }

        public SystemChangeClickHandler(IHandlerInputSelector handlerInputSelector, IViewSelectorItem viewSelectorItem)
        {
            _handlerInputSelector = handlerInputSelector;
            _viewSelectorItem = viewSelectorItem;
        }
        
        public void Init()
        {
            _viewSelectorItem.UpdateItems(_handlerInputSelector.AvailableHandlers);
            _viewSelectorItem.OnSelectItem += OnSelectItem;
            
            var initHandlerIndex = 0;
            OnSelectItem(initHandlerIndex);
            _viewSelectorItem.SelectItem(initHandlerIndex);
        }

        private void OnSelectItem(int index)
        {
            _handlerInputSelector.ChangeHandler(_handlerInputSelector.AvailableHandlers[index]);
        }

        public void Update(float dt)
        {
        }

        public void Cleanup()
        {
            _viewSelectorItem.OnSelectItem -= OnSelectItem;
            _handlerInputSelector.Reset();
        }
    }
}