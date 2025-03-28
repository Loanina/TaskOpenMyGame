using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

namespace App.Scripts.Scenes.SceneCalculator.Features.ViewLog
{
    public class ViewLogMono : MonoBehaviour, IViewLog
    {
        [SerializeField] private TextMeshProUGUI logLabel;
        [SerializeField] private int maxLogCount;
        
        private readonly List<string> _messages = new();
        private readonly StringBuilder _buffer = new();

        public void AddLog(string message)
        {
            _messages.Add(message);
            if (_messages.Count > maxLogCount)
            {
                _messages.RemoveAt(_messages.Count - 1);
            }

            UpdateViewLog();
        }

        private void UpdateViewLog()
        {
            foreach (string message in _messages)
            {
                _buffer.AppendLine(message);
            }

            logLabel.text = _buffer.ToString();
            _buffer.Clear();
        }
    }
}