using AltaHyperCasual.Utils.Updatable;
using UnityEngine;

namespace AltaHyperCasual.Code.Camera
{
    public interface ICamera : IUpdatable
    {
        void Initialize(Transform transform, Transform targetTransform);
        void HandleMovement();
    }
}
