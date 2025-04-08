using AltaHyperCasual.Code.Animations.JellyAnimation;
using AltaHyperCasual.Utils.Updatable;
using UnityEngine;

namespace AltaHyperCasual.Code.Player
{
    public interface IPlayer : IUpdatable
    {
        void Initialize(Transform transform, float playerRadius, IJellyAnimation jellyAnimation);
        void MoveTowards(Vector3 target);
    }
}
