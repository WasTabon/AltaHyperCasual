using AltaHyperCasual.Data;
using UnityEngine;

namespace AltaHyperCasual.Code.Animations.JellyAnimation
{
    public class JellyAnimationController : IJellyAnimation
    {
        private float _deformSpeed;
        private float _deformAmount;
        private float _scaleSpeed; 
        private float _animationTimer;

        private Vector3 _targetScale;
        
        private Transform _transform;
        
        public JellyAnimationController(Transform transform, float deformSpeed, float deformAmount, float scaleSpeed)
        {
            _transform = transform;
            _deformSpeed = deformSpeed;
            _deformAmount = deformAmount;
            _scaleSpeed = scaleSpeed;
        }

        public void SetSize(float radius)
        {
            _targetScale = Vector3.one * radius;
            _animationTimer = 0f;
        }

        public void PlayAnimation(float deltaTime)
        {
            _animationTimer += deltaTime * _deformSpeed;
            float jellyX = Mathf.Sin(_animationTimer) * _deformAmount;
            float jellyY = Mathf.Sin(_animationTimer + 1f) * _deformAmount;

            Vector3 offset = new Vector3(jellyX, jellyY, 0f);
            Vector3 scale = _targetScale + Vector3.Scale(_targetScale, offset);

            _transform.localScale = Vector3.Lerp(_transform.localScale, scale, deltaTime * _scaleSpeed);
        }

        public void DecreaseSize(float deltaTime, float speed)
        {
            Vector3 reduce = Vector3.one * speed * deltaTime;
            _targetScale -= reduce;
        }
        public void IncreaseSize(float deltaTime, float speed)
        {
            Vector3 reduce = Vector3.one * speed * deltaTime;
            _targetScale += reduce;
        }
    }
}
