using System;
using System.Collections.Generic;
using App.Scripts.Features.Scenes.SceneNavigation.Config;
using UnityEngine;

namespace App.Scripts.Features.Scenes.SceneSelector.View.ViewSwitcher
{
    public class ViewItemsSelector : MonoBehaviour
    {
        public event Action<SceneInfo> OnItemSelected;


        [SerializeField] private RectTransform container;

        [SerializeField] private ViewLabelButton prefabButton;

        private Stack<ViewLabelButton> _poolItems = new();

        private List<ViewLabelButton> _views = new();

        public void UpdateItems(IEnumerable<SceneInfo> sceneInfos)
        {
            ClearItems();

            foreach (SceneInfo sceneInfo in sceneInfos)
            {
                var viewButton = CreateView();
                viewButton.UpdateLabel(sceneInfo.SceneViewName);

                viewButton.OnClick += () =>
                {
                    OnItemSelected?.Invoke(sceneInfo);
                };
                
                _views.Add(viewButton);
            }
            
        }

        private ViewLabelButton CreateView()
        {
            if (_poolItems.Count > 0)
            {
                var item = _poolItems.Pop();
                item.gameObject.SetActive(true);
                return item;
            }

            return Instantiate(prefabButton, container);
        }

        private void ClearItems()
        {
            foreach (ViewLabelButton viewLabelButton in _views)
            {
                ReturnToPool(viewLabelButton);
            }
            
            _views.Clear();
        }

        private void ReturnToPool(ViewLabelButton viewLabelButton)
        {
            _poolItems.Push(viewLabelButton);
            viewLabelButton.Reset();
            viewLabelButton.gameObject.SetActive(false);
        }
    }
}