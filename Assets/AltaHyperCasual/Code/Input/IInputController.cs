using UnityEngine;

namespace AltaHyperCasual.Code.Input
{
    public interface IInputController
    {
        void OnInputStart(Vector2 screenPosition);
        void OnInputHold(Vector2 screenPosition);
        void OnInputEnd(Vector2 screenPosition);

        void Tick(float deltaTime);
    }
}
