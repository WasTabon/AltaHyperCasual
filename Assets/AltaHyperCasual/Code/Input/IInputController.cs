using AltaHyperCasual.Utils.Updatable;
using UnityEngine;

namespace AltaHyperCasual.Code.Input
{
    public interface IInputController : IUpdatable
    {
        void OnInputStart(Vector2 screenPosition);
        void OnInputHold(Vector2 screenPosition);
        void OnInputEnd(Vector2 screenPosition);
    }
}
