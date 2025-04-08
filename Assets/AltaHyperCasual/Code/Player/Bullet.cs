using System;
using AltaHyperCasual.Code.Animations.JellyAnimation;
using AltaHyperCasual.Data;
using AltaHyperCasual.Utils.TriggerListener;
using AltaHyperCasual.Code.VFXModule;
using UnityEngine;

namespace AltaHyperCasual.Code.Player
{
    public class Bullet : IBullet
    {
        public event Action OnMoveStart;
        public event Action OnMoveEnd;
        
        private float _moveSpeed;
        private float _decreaseSpeed;
        
        private IJellyAnimation _jellyAnimation;
        private IVFXController _vfxController;
        private Transform _transform;
        private Transform _shootPosTransform;

        private bool _isMoving;

        public void Initialize(float moveSpeed ,Transform transform, IJellyAnimation jellyAnimation, IVFXController vfxController, float decreaseSpeed)
        {
            _moveSpeed = moveSpeed;
            _transform = transform;
            _jellyAnimation = jellyAnimation;
            _vfxController = vfxController;
            _decreaseSpeed = decreaseSpeed;

            TriggerListener triggerListener = _transform.gameObject.AddComponent<TriggerListener>();
            triggerListener.SetCollisionTag(Constants.TAG_TREE_COLLISION);

            triggerListener.OnTriggerEnterEvent += Explode;

            _shootPosTransform = _transform.parent.Find(Constants.TAG_PLAYER_SHOOTPOS).GetComponent<Transform>();

            ResetSize();
        }
        
        public void MoveTowards(float deltaTime)
        {
            if (_isMoving)
            {
                _transform.position += _transform.forward * _moveSpeed * deltaTime;
            }
        }

        public void Infect()
        {
        
        }

        public void HandleShootStart()
        {
            Debug.Log("Shot Start");
            
            _transform.position = _shootPosTransform.position;
            _transform.gameObject.SetActive(true);
            _transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }

        public void HandleShootHold()
        {
            _jellyAnimation.IncreaseSize(Time.deltaTime, _decreaseSpeed);
        }

        public void HandleShootEnd()
        {
            OnMoveStart?.Invoke();
            _isMoving = true;
        }

        public void Tick(float deltaTime)
        {
            _jellyAnimation.PlayAnimation(deltaTime);
            MoveTowards(deltaTime);
        }

        public void Dispose()
        {
            if (_transform != null)
            {
                var listener = _transform.GetComponent<TriggerListener>();
                if (listener != null)
                {
                    listener.OnTriggerEnterEvent -= Explode;
                }
            }
        }
        
        private void ResetSize()
        {
            _isMoving = false;
            _transform.localScale = Vector3.zero;
            _transform.gameObject.SetActive(false);
        }

        private void Explode(Collider coll)
        {
            _vfxController.SpawnVFX(VFXType.Explosion, _transform.position);
            Infect();
            ResetSize();
        }
    }
}
