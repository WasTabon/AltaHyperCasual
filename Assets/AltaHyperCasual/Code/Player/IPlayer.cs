using AltaHyperCasual.Code.Animations.JellyAnimation;
using AltaHyperCasual.Code.Movable;
using AltaHyperCasual.Utils.Updatable;
using UnityEngine;

namespace AltaHyperCasual.Code.Player
{
    public interface IPlayer : IUpdatable, IMovable
    {
        void Initialize(Transform transform, float playerRadius, IJellyAnimation jellyAnimation, float decreaseSpeed, float player speed);

        void HandleShootStart();
        void HandleShootEnd();
    }
}
