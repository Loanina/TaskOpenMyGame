using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace App.Scripts.Scenes.SceneHeroes.Features.Units.UnitSelection.UnitTypeSelector
{
    public class ViewSelectorItem : MonoBehaviour, IViewSelectorItem
    {
        [SerializeField] private TMP_Dropdown dropdown;
        
        public event Action<int> OnSelectItem;

        private readonly List<TMP_Dropdown.OptionData> _options = new();
        private readonly List<string> _items = new();

        private void Awake()
        {
            dropdown.onValueChanged.AddListener(OnChangeValue);
        }

        private void OnChangeValue(int index)
        {
            OnSelectItem?.Invoke(index);
        }


        public void UpdateItems(IEnumerable<string> availableUnits)
        {
            _options.Clear();
            _items.Clear();
            
            
            foreach (var unitType in availableUnits)
            {
                _options.Add(new TMP_Dropdown.OptionData(unitType));
                _items.Add(unitType);
            }

            dropdown.options = _options;
        }

        public void SelectItem(int index)
        {
            dropdown.SetValueWithoutNotify(index);
        }
    }
}