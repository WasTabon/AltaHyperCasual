using UnityEngine;

namespace AltaHyperCasual.Code.Player
{
    public interface IPlayer
    {
        void Initialize(Transform transform, float playerRadius);
        void SetSize(float radius);
        void MoveTowards(Vector3 target);
    }
}
