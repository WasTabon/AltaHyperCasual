using AltaHyperCasual.Code.Configs;
using AltaHyperCasual.Code.Player;
using UnityEngine;

namespace AltaHyperCasual.Code.Core
{
    public class GameController
    {
        private readonly GameConfig _config;
        private readonly IPlayer _player;

        public GameController(GameConfig config, Transform playerTransform)
        {
            _config = config;
            _player = new PlayerController();
            
            _player.Initialize(playerTransform, config.PlayerRadius);
        }

        public void Tick(float deltaTime)
        {
            
        }
    }
}
