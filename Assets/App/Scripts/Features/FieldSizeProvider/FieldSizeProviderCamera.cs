using UnityEngine;

namespace App.Scripts.Features.FieldSizeProvider
{
    public class FieldSizeProviderCamera : IFieldSizeProvider
    {
        private readonly Camera _camera;

        public FieldSizeProviderCamera(Camera camera)
        {
            _camera = camera;
        }
        
        public Rect GetFieldRect()
        {
            Vector2 pos = _camera.transform.position;
            var cameraOrthographicSize = _camera.orthographicSize;
            var size = new Vector2(_camera.aspect * cameraOrthographicSize, cameraOrthographicSize);
            
            return new Rect(pos - size, size * 2);
        }
    }
}