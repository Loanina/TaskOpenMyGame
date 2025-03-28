using App.Scripts.Modules.BaseView;
using UnityEngine;

namespace App.Scripts.Features.GridField.GridContainer
{
    public abstract class ViewCell : MonoView
    {
        private IViewGridContainer _viewGridContainer;
        public abstract void SetSize(float size);
        private float Layer { get;set; }

        public void Initialize(float layer)
        {
            Layer = layer;
        }

        public void OnSetupGridContainer(IViewGridContainer viewGridContainer)
        {
            _viewGridContainer = viewGridContainer;
        }
        
        public void SetLayerPosition(Vector2 gridToPosition)
        {
            Vector3 pos = gridToPosition;
            pos.z = Layer;
            localPosition = pos;
        }

        public void SetGridPosition(Vector2Int position)
        {
            SetLayerPosition(_viewGridContainer.GridToPosition(position));
        }

        public override void Remove()
        {
            if (_viewGridContainer != null)
            {
                _viewGridContainer.RemoveView(this);
            }
            
            base.Remove();
        }

        public abstract void SetColor(Color color);

        public void SetLayer(float configPathLayer)
        {
            Layer = configPathLayer;
        }
    }
}