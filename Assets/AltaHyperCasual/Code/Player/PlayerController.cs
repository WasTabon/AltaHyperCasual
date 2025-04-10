using System;
using AltaHyperCasual.Code.Animations.JellyAnimation;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace AltaHyperCasual.Code.Player
{
    public class PlayerController : IPlayer
    {
        public event Action OnMoveToPoint;
        public event Action OnStop;
        
        private float _playerSpeed;
        private float _decreaseSpeed;
        private float _playerRadius;
        
        private IJellyAnimation _jellyAnimation;
        private Transform _transform;

        private bool _isMoving;
        
        public void Initialize(Transform transform, float playerRadius, IJellyAnimation jellyAnimation, float decreaseSpeed, float playerSpeed)
        {
            _transform = transform;
            _jellyAnimation = jellyAnimation;
            _decreaseSpeed = decreaseSpeed;
            _playerSpeed = playerSpeed;
            _playerRadius = playerRadius;
            
            _jellyAnimation.SetSize(_playerRadius);
        }

        public void HandleShootStart()
        {
            _jellyAnimation.DecreaseSize(Time.deltaTime, _decreaseSpeed);
        }

        public void HandleShootEnd()
        {
            if (IsPathClear())
            {
                OnMoveToPoint?.Invoke();
                _isMoving = true;
            }
            else
            {
                OnStop?.Invoke();
            }
        }

        public void MoveTowards(float deltaTime)
        {
            if (_isMoving)
            { 
                _transform.position += _transform.forward * _playerSpeed * deltaTime;   
            }
        }
        
        public void Tick(float deltaTime)
        {
            _jellyAnimation.PlayAnimation(deltaTime);
            MoveTowards(deltaTime);
        }

        private bool IsPathClear()
        {
            RaycastHit[] hits = Physics.SphereCastAll(_transform.position, _transform.localScale.x / 2, _transform.forward, 50, ~0, QueryTriggerInteraction.Collide);

            foreach (RaycastHit hit in hits)
            {
                if (hit.collider != null && hit.collider.isTrigger)
                {
                    return false;
                }
            }
            return true;
        }
    }
}