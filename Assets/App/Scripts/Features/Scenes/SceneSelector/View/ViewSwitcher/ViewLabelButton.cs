using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Features.Scenes.SceneSelector.View.ViewSwitcher
{
    public class ViewLabelButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private TextMeshProUGUI textLabel;

        public event Action OnClick; 

        private void Awake()
        {
            button.onClick.AddListener(() =>
            {
                OnClick?.Invoke();
            });
        }

        public void UpdateLabel(string label)
        {
            textLabel.text = label;
        }

        public void Reset()
        {
            OnClick = null;
        }
    }
}