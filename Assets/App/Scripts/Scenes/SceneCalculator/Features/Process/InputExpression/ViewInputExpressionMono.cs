using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Scenes.SceneCalculator.Features.Process.InputExpression
{
    public class ViewInputExpressionMono : MonoBehaviour, IViewInputExpression
    {
        [SerializeField] private TMP_InputField labelKey;
        [SerializeField] private TMP_InputField labelExpression;
        [SerializeField] private Button button;

        public string Key => labelKey.text;
        public string Expression => labelExpression.text;
        public event Action OnApply;

        private void Awake()
        {
            button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            OnApply?.Invoke();
        }
    }
}