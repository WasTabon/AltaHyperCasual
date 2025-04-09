using System;
using AltaHyperCasual.Code.Animations.JellyAnimation;
using AltaHyperCasual.Code.Movable;
using AltaHyperCasual.Utils.Updatable;
using UnityEngine;

namespace AltaHyperCasual.Code.Player
{
    public interface IPlayer : IUpdatable, IMovable
    {
        event Action OnMoveToPoint;
        event Action OnStop;
        
        void Initialize(Transform transform, float playerRadius, IJellyAnimation jellyAnimation, float decreaseSpeed, float playerSpeed);

        void HandleShootStart();
        void HandleShootEnd();
    }
}
