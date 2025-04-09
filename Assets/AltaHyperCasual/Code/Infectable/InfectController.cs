using AltaHyperCasual.Data;
using UnityEngine;

namespace AltaHyperCasual.Code.Infectable
{
    public class InfectController : MonoBehaviour, IInfectable
    {
        private Quaternion _startRotation;
        private Quaternion _targetRotation;
        private float _rotationElapsed;
        private bool _isRotating;
        private float _rotationDuration;

        private float _inactiveTimer;
        private bool _waitingToDisable;

        public void Infect()
        {
            GetComponent<Collider>().enabled = false;
            
            Invoke(nameof(StartRotation), Constants.TREE_FALL_DURATION);
        }

        private void StartRotation()
        {
            _startRotation = transform.rotation;
            _targetRotation = Quaternion.Euler(90f, _startRotation.eulerAngles.y, Random.Range(0f, 360f));
            _rotationDuration = Constants.TREE_BURN_DURATION;
            _rotationElapsed = 0f;
            _isRotating = true;
        }

        private void Update()
        {
            if (_isRotating)
            {
                _rotationElapsed += Time.deltaTime;
                float time = Mathf.Clamp01(_rotationElapsed / _rotationDuration);
                transform.rotation = Quaternion.Slerp(_startRotation, _targetRotation, time);

                if (time >= 1f)
                {
                    _isRotating = false;
                    _inactiveTimer = Constants.TREE_INACTIVE_DURATION;
                    _waitingToDisable = true;
                }
            }

            if (_waitingToDisable)
            {
                _inactiveTimer -= Time.deltaTime;
                if (_inactiveTimer <= 0f)
                {
                    _waitingToDisable = false;
                    gameObject.SetActive(false);
                }
            }
        }
    }
}