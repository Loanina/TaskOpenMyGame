using UnityEngine;

namespace App.Scripts.Features.GridField.GridContainer
{
    public class ViewCellSpriteRender : ViewCell
    {
        [SerializeField] private SpriteRenderer spriteRenderer;


        public void SetupSprite(Sprite sprite)
        {
            spriteRenderer.sprite = sprite;
        }
        
        public override void SetSize(float size)
        {
            spriteRenderer.size = new Vector2(size, size);
        }

        public override void SetColor(Color color)
        {
            spriteRenderer.color = color;
        }
    }
}