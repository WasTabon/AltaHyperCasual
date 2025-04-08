using AltaHyperCasual.Code.Animations.JellyAnimation;
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
        public void MoveTowards(Vector3 target)
        {
            
        }
        public void Tick(float deltaTime)
        {
            _jellyAnimation.PlayAnimation(deltaTime);
        }
    }
}