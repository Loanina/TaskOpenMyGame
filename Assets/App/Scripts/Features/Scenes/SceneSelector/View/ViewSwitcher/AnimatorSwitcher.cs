using System.Threading.Tasks;
using App.Scripts.Modules.TweenHelper;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Features.Scenes.SceneSelector.View.ViewSwitcher
{
    public class AnimatorSwitcher : MonoBehaviour
    {
        [SerializeField] private RectTransform container;

        [SerializeField] private float duration;
        
        private Sequence _animation;
        
        public Task Show()
        {
            CancelAnimation();
            
            _animation = DOTween.Sequence();

            _animation.Append(container.DOAnchorPosX(0, duration).SetEase(Ease.InSine));
            _animation.AppendCallback(CompleteAnimation);
            
            return _animation.Await();
        }

        private void CancelAnimation()
        {
            if (_animation is null)
            {
                return;
            }

            _animation.Kill(true);
            _animation = null;
        }

        private void CompleteAnimation()
        {
            _animation = null;
        }

        public Task Hide()
        {
            CancelAnimation();
            _animation = DOTween.Sequence();

            _animation.Append(container.DOAnchorPosX(-container.rect.width, duration).SetEase(Ease.InSine));
            _animation.AppendCallback(CompleteAnimation);
            
            return _animation.Await();
        }
    }
}