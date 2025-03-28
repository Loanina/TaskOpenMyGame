using App.Scripts.Scenes.SceneMatrix.Features.FigurePreviewContainer.Model;
using UnityEngine;

namespace App.Scripts.Scenes.SceneMatrix.Features.FigurePreviewContainer.View.ViewFigureContainer
{
    public class ViewFigureShape : MonoBehaviour
    {
        [SerializeField] private RectTransform container;
        [SerializeField] private ViewCellUI prefabCell;

        public ViewModelFigure Figure { get; private set; }

        public void SetupShape(ViewModelFigure figure, float cellSize)
        {
            Figure = figure;

            for (int i = 0; i < figure.Grid.Height; i++)
            {
                for (int j = 0; j < figure.Grid.Width; j++)
                {
                    if (figure.Grid[j, i])
                    {
                        var view = Instantiate(prefabCell, container);
                        view.SetSize(cellSize);
                        view.SetColor(figure.Color);
                        var place = new Vector2(j, i);
                        view.SetPosition( cellSize * (place + new Vector2(0.5f, 0.5f)));
                    }
                }
            }

            container.sizeDelta = new Vector2(cellSize * figure.Grid.Width, cellSize * figure.Grid.Height);
        }

        public void Remove()
        {
            Destroy(gameObject);
        }

        public Rect GetRect()
        {
            return container.rect;
        }
    }
}