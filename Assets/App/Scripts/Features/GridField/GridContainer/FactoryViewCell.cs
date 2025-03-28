using App.Scripts.Modules.Factory;
using UnityEngine;

namespace App.Scripts.Features.GridField.GridContainer
{
    public class FactoryViewCell : IFactory<ViewCell>
    {
        private readonly ViewCellSpriteRender _prefab;

        public FactoryViewCell(ViewCellSpriteRender prefab)
        {
            _prefab = prefab;
        }
        
        public ViewCellSpriteRender Create(float layer, Sprite sprite)
        {
            var viewObstacle = Object.Instantiate(_prefab);
            
            viewObstacle.Initialize(layer);
            viewObstacle.SetupSprite(sprite);
            
            return viewObstacle;
        }

        public ViewCell Create()
        {
            return Object.Instantiate(_prefab);
        }
    }
}