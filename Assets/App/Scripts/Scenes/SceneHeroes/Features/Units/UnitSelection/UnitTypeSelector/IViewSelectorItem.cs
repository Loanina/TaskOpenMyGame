using System;
using System.Collections.Generic;

namespace App.Scripts.Scenes.SceneHeroes.Features.Units.UnitSelection.UnitTypeSelector
{
    public interface IViewSelectorItem
    {
        event Action<int> OnSelectItem;

        void UpdateItems(IEnumerable<string> itemsLabels);

        void SelectItem(int index);
    }
}