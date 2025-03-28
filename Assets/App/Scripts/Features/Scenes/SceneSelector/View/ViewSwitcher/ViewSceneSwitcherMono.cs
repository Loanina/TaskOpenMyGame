using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Scripts.Features.Scenes.SceneNavigation.Config;
using UnityEngine;

namespace App.Scripts.Features.Scenes.SceneSelector.View.ViewSwitcher
{
    public class ViewSceneSwitcherMono : MonoBehaviour, IViewSceneSwitcher
    {
        public event Action<SceneInfo> OnItemSelected;

        [SerializeField] private ViewItemsSelector selector;
        [SerializeField] private AnimatorSwitcher animator;
        
        public bool IsShow { get; private set; }
        
        private void Awake()
        {
            selector.OnItemSelected += ItemSelected;
        }

        private void ItemSelected(SceneInfo sceneInfo)
        {
            OnItemSelected?.Invoke(sceneInfo);
        }

        public void UpdateItems(IEnumerable<SceneInfo> sceneInfos)
        {
            selector.UpdateItems(sceneInfos);   
        }

        public Task Show()
        {
            IsShow = true;
            return animator.Show();
        }

        public Task Hide()
        {
            IsShow = false;
            return animator.Hide();
        }
    }
}