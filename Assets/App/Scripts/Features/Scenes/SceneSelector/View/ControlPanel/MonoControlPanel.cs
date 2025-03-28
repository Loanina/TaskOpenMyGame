using System;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Features.Scenes.SceneSelector.View.ControlPanel
{
    public class MonoControlPanel : MonoBehaviour, IControlPanel
    {
        [SerializeField] private Button buttonMenuScenes;
        
        public event Action OnScenePanelClick;

        private void Awake()
        {
            buttonMenuScenes.onClick.AddListener(()=>OnScenePanelClick?.Invoke());
        }
    }
}