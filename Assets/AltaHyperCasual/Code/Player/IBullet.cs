using AltaHyperCasual.Code.Animations.JellyAnimation;
using AltaHyperCasual.Code.Movable;
using AltaHyperCasual.Utils.Updatable;
using UnityEngine;

namespace AltaHyperCasual.Code.Player
{
    public interface IBullet : IMovable, IUpdatable
    {
        void Initialize(float moveSpeed ,Transform transform, IJellyAnimation jellyAnimation);
        void Infect();
    }
}
