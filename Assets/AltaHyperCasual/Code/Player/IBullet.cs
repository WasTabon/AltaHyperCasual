using System;
using AltaHyperCasual.Code.Animations.JellyAnimation;
using AltaHyperCasual.Code.Movable;
using AltaHyperCasual.Code.VFXModule;
using AltaHyperCasual.Utils.Updatable;
using UnityEngine;

namespace AltaHyperCasual.Code.Player
{
    public interface IBullet : IMovable, IUpdatable
    {
        event Action OnMoveStart;
        event Action OnMoveEnd;
        void Initialize(float moveSpeed ,Transform transform, IJellyAnimation jellyAnimation, IVFXController vfxController, float decreaseSpeed);
        void Infect(Collider coll);
        void HandleShootStart();
        void HandleShootHold();
        void HandleShootEnd();
    }
}
