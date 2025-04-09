using System;
using UnityEngine;

namespace AltaHyperCasual.Code.WinController
{
    public class WinController : IWin
    {
        public event Action OnWin;
        public event Action OnLose;
        
        private Transform _playerTransform;
        private Transform _finishTransform;

        public void Initialize(Transform playerTransform, Transform finishTransform)
        {
            _playerTransform = playerTransform;
            _finishTransform = finishTransform;
        }

        public void CheckWin()
        {
            if (Distance(_playerTransform.position, _finishTransform.position) <= 0.1f)
            {
                OnWin?.Invoke();
            }
        }

        public void CheckLose()
        {
            if (_playerTransform.localScale.x <= 0.1f)
            {
                OnLose?.Invoke();
            }
        }
        
        private float Distance(Vector3 a, Vector3 b)
        {
            return (a - b).magnitude;
        }
    }
}
