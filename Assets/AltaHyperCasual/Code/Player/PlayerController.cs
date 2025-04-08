using AltaHyperCasual.Code.Animations.JellyAnimation;
using AltaHyperCasual.Code.Movable;
using UnityEngine;

namespace AltaHyperCasual.Code.Player
{
    public class PlayerController : IPlayer
    {
        private float _decreaseSpeed;
        
        private IJellyAnimation _jellyAnimation;
        private Transform _transform;
        
        public void Initialize(Transform transform, float playerRadius, IJellyAnimation jellyAnimation, float decreaseSpeed)
        {
            _transform = transform;
            _jellyAnimation = jellyAnimation;
            _decreaseSpeed = decreaseSpeed;
            
            _jellyAnimation.SetSize(playerRadius);
        }

        public void HandleShootStart()
        {
            _jellyAnimation.DecreaseSize(Time.deltaTime, _decreaseSpeed);
        }

        public void HandleShootEnd()
        {
            
        }

        public void MoveTowards()
        {
            
        }
        public void Tick(float deltaTime)
        {
            _jellyAnimation.PlayAnimation(deltaTime);
        }
    }
}