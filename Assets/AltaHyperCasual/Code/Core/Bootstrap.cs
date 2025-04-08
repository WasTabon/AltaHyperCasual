using AltaHyperCasual.Code.Configs;
using UnityEngine;

namespace AltaHyperCasual.Code.Core
{
    public class Bootstrap : MonoBehaviour
    {
        [Header("GAME SETTINGS")]
        [SerializeField] private GameConfig _config;
        [SerializeField] private Transform _playerTransform;
        
        private GameController _game;

        private void Awake()
        {
            _game = new GameController(_config, _playerTransform);
        }

        private void Update()
        {
            _game.Tick(Time.deltaTime);
        }
    }
}
