using System;
using UnityEngine;

namespace AltaHyperCasual.Code.Input
{
    public class InputController : IInputController
    {
        public event Action OnHoldStart;
        public event Action OnHoldInvoke;
        public event Action OnHoldEnd;
        
        private bool _isInputActive;

        public void Tick(float deltaTime)
        {
#if UNITY_EDITOR
            HandleMouseInput();
#else
            HandleTouchInput();
#endif
        }

        private void HandleMouseInput()
        {
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                _isInputActive = true;
                OnInputStart(UnityEngine.Input.mousePosition);
            }
            else if (UnityEngine.Input.GetMouseButton(0) && _isInputActive)
            {
                OnInputHold(UnityEngine.Input.mousePosition);
            }
            else if (UnityEngine.Input.GetMouseButtonUp(0) && _isInputActive)
            {
                _isInputActive = false;
                OnInputEnd(UnityEngine.Input.mousePosition);
            }
        }

        private void HandleTouchInput()
        {
            if (UnityEngine.Input.touchCount == 0)
                return;

            Touch touch = UnityEngine.Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _isInputActive = true;
                    OnInputStart(touch.position);
                    break;

                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    if (_isInputActive)
                        OnInputHold(touch.position);
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    if (_isInputActive)
                    {
                        _isInputActive = false;
                        OnInputEnd(touch.position);
                    }
                    break;
            }
        }
        
        public void OnInputStart(Vector2 screenPosition)
        {
            OnHoldStart?.Invoke();
        }

        public void OnInputHold(Vector2 screenPosition)
        {
            OnHoldInvoke?.Invoke();
        }

        public void OnInputEnd(Vector2 screenPosition)
        {
            OnHoldEnd?.Invoke();
        }
    }
}
