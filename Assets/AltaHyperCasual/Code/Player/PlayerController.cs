using AltaHyperCasual.Code.Animations.JellyAnimation;
using AltaHyperCasual.Code.Movable;
using UnityEngine;

namespace AltaHyperCasual.Code.Player
{
    public class PlayerController : IPlayer
    {
        private float _playerSpeed;
        private float _decreaseSpeed;
        
        private IJellyAnimation _jellyAnimation;
        private Transform _transform;
        
        public void Initialize(Transform transform, float playerRadius, IJellyAnimation jellyAnimation, float decreaseSpeed, float playerSpeed)
        {
            _transform = transform;
            _jellyAnimation = jellyAnimation;
            _decreaseSpeed = decreaseSpeed;
            _playerSpeed = playerSpeed;
            
            _jellyAnimation.SetSize(playerRadius);
        }

        public void HandleShootStart()
        {
            _jellyAnimation.DecreaseSize(Time.deltaTime, _decreaseSpeed);
        }

        public void HandleShootEnd()
        {
            
        }

        public void MoveTowards(float deltaTime)
        {
            _transform.position += _transform.forward * _playerSpeed * deltaTime;
        }
        
        public void Tick(float deltaTime)
        {
            _jellyAnimation.PlayAnimation(deltaTime);
        }
    }
}