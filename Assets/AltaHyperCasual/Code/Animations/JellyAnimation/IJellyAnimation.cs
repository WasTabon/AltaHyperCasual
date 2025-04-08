using UnityEngine;

namespace AltaHyperCasual.Code.Animations.JellyAnimation
{
    public interface IJellyAnimation
    {
        void SetSize(float radius);
        void PlayAnimation(float deltaTime);
    }
}
