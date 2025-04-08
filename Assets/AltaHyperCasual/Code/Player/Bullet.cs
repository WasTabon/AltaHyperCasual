using AltaHyperCasual.Code.Animations.JellyAnimation;
using UnityEngine;

namespace AltaHyperCasual.Code.Player
{
    public class Bullet : IBullet
    {
        private IJellyAnimation _jellyAnimation;
        private Transform _transform;

        private bool _isMoving;
        
        public void Initialize(float moveSpeed ,Transform transform, IJellyAnimation jellyAnimation)
        {
            _transform = transform;
            _jellyAnimation = jellyAnimation;
            
            ResetSize();
        }
        
        public void MoveTowards()
        {
            if (_isMoving)
            {
                
                
            }
        }

        public void Infect()
        {
        
        }

        public void Tick(float deltaTime)
        {
            _jellyAnimation.PlayAnimation(deltaTime);
            MoveTowards();
        }

        private void ResetSize()
        {
            _transform.localScale = Vector3.zero;
            _transform.gameObject.SetActive(false);
            _isMoving = false;
        }
    }
}
