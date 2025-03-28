using System;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Features.LevelSelection
{
    public class ViewSwitchNavigator : MonoBehaviour, IViewSwitchNavigator
    {
        [SerializeField] private Button buttonNextLevel;
        [SerializeField] private Button buttonPrevLevel;
        
        public event Action<int> ChangeLevel;

        private void Awake()
        {
            buttonNextLevel.onClick.AddListener(NextLevelClick);
            buttonPrevLevel.onClick.AddListener(PrevLevelClick);
        }

        private void PrevLevelClick()
        {
            ChangeLevel?.Invoke(-1);
        }

        private void NextLevelClick()
        {
            ChangeLevel?.Invoke(1);
        }
    }
}