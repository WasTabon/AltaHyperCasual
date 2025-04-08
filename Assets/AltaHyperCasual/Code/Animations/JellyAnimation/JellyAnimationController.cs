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

            Vector3 jellyOffset = new Vector3(jellyX, jellyY, 0f);
            Vector3 scaledTarget = _targetScale + Vector3.Scale(_targetScale, jellyOffset);
            
            _transform.localScale = Vector3.Lerp(_transform.localScale, scaledTarget, deltaTime * _scaleSpeed);
        }
    }
}
