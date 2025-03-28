using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Scenes.SceneMatrix.Features.FigurePreviewContainer.View.ViewFigureContainer
{
    public class ViewCellUI : MonoBehaviour
    {
        [SerializeField] private Image view;
        [SerializeField] private RectTransform container;
        [SerializeField] private float spacing;
        public void SetSize(float cellSize)
        {
            container.sizeDelta = new Vector2(cellSize - spacing, cellSize - spacing);
        }

        public void SetPosition(Vector2 place)
        {
            container.anchoredPosition = place;
        }

        public void SetColor(Color figureColor)
        {
            view.color = figureColor;
        }
    }
}