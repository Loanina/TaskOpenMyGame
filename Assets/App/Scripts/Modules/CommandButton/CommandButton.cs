using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Modules.CommandButton
{
    public class CommandButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        private ICommandButton _commandButton;

        private void Awake()
        {
            button.onClick.AddListener(Click);
        }

        private void Click()
        {
            _commandButton?.Execute();
        }

        public void SetupCommand(ICommandButton commandButton)
        {
            _commandButton = commandButton;
        }
    }
}