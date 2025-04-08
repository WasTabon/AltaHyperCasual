namespace AltaHyperCasual.Code.Animations.JellyAnimation
{
    public interface IJellyAnimation
    {
        void SetSize(float radius);
        void PlayAnimation(float deltaTime);
        void DecreaseSize(float deltaTime, float speed);
        void IncreaseSize(float deltaTime, float speed);
    }
}
