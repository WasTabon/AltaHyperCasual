using AltaHyperCasual.Utils.Updatable;
using System;
using UnityEngine;

namespace AltaHyperCasual.Code.Input
{
    public interface IInputController : IUpdatable
    {
        event Action OnHoldStart;
        event Action OnHoldInvoke;
        event Action OnHoldEnd;
        
        void OnInputStart(Vector2 screenPosition);
        void OnInputHold(Vector2 screenPosition);
        void OnInputEnd(Vector2 screenPosition);
    }
}
