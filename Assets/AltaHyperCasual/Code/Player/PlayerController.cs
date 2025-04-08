using AltaHyperCasual.Code.Animations.JellyAnimation;
using AltaHyperCasual.Code.Movable;
using UnityEngine;

namespace AltaHyperCasual.Code.Player
{
    public class PlayerController : IPlayer
    {
        private IJellyAnimation _jellyAnimation;
        private Transform _transform;
        
        public void Initialize(Transform transform, float playerRadius, IJellyAnimation jellyAnimation)
        {
            _transform = transform;
            _jellyAnimation = jellyAnimation;
            
            _jellyAnimation.SetSize(playerRadius);
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