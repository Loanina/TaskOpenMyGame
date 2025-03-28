using System.Collections.Generic;
using System.Linq;
using App.Scripts.Scenes.SceneMatrix.Features.FigurePreviewContainer.Model;
using UnityEngine;

namespace App.Scripts.Scenes.SceneMatrix.Features.FigurePreviewContainer.View.ViewFigureContainer
{
    public class ViewFigureContainer : MonoBehaviour
    {
        [SerializeField] private RectTransform container;

        [SerializeField] private ViewFigureShape prefabShape;

        [SerializeField] private float spacing;
        private readonly List<ViewFigureShape> _figures = new();
        public void UpdateFigureList(List<ViewModelFigure> figures)
        {
            Clear();

            if (figures.Count == 0)
            {
                return;
            }
            
            int maxWidth = figures.Max(x => x.Grid.Width);

            float size = container.rect.size.x / maxWidth;

            float totalSize = 0;
            foreach (var figure in figures)
            {
                var view = Instantiate(prefabShape, container);
                
                view.SetupShape(figure, size);
                var rect = view.GetRect();
                totalSize += rect.size.y + spacing;
                
                _figures.Add(view);
            }

            container.sizeDelta = new Vector2(0, totalSize);
        }

        public void Clear()
        {
            foreach (var figure in _figures)
            {
                figure.Remove();
            }
            
            _figures.Clear();
        }
    }
}