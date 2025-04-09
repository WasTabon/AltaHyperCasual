using UnityEngine;

namespace AltaHyperCasual.Code.Camera
{
    public class CameraController : ICamera
    {
        private float smoothSpeed = 5f;
        
        private Vector3 _offset;
        
        private Transform _transform;
        private Transform _targetTransform;
        
        public void Initialize(Transform transform, Transform targetTransform)
        {
            _transform = transform;
            _targetTransform = targetTransform;
            
            _offset = _transform.position - _targetTransform.position;
        }
        
        public void HandleMovement()
        {
            Vector3 desiredPosition = _targetTransform.position + _offset;
            Vector3 smoothedPosition = Vector3.Lerp(_transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

            _transform.position = smoothedPosition;
        }
        
        public void Tick(float deltaTime)
        {
            HandleMovement();
        }
    }
}
