using TMPro;
using UnityEngine;

namespace App.Scripts.Scenes.SceneMatrix.Features.Scores.View
{
    public class ViewScore : MonoBehaviour, IViewScore
    {
        [SerializeField] private TextMeshProUGUI label;
        [SerializeField] private string format;
        
        public void UpdateScore(int value)
        {
            label.text = string.Format(format, value);
        }
        
    }
}