using AltaHyperCasual.Code.Animations.JellyAnimation;
using AltaHyperCasual.Code.Configs;
using AltaHyperCasual.Code.Player;
using AltaHyperCasual.Utils.Updatable;
using UnityEngine;

namespace AltaHyperCasual.Code.Core
{
    public class GameController : IUpdatable
    {
        private readonly GameConfig _config;
        private readonly IPlayer _player;
        private readonly IJellyAnimation _playerJellyAnimation;

        public GameController(GameConfig config, Transform playerTransform)
        {
            _config = config;
            _player = new PlayerController();
            _playerJellyAnimation = new JellyAnimationController(playerTransform, config.DeformSpeed, config.DeformAmount, config.ScaleSpeed);

            _player.Initialize(playerTransform, config.PlayerRadius, _playerJellyAnimation);
        }

        public void Tick(float deltaTime)
        {
            _player.Tick(deltaTime);
        }
    }
}
