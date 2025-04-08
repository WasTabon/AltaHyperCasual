using AltaHyperCasual.Code.Configs;
using UnityEngine;

namespace AltaHyperCasual.Code.Core
{
    public class Bootstrap : MonoBehaviour
    {
        [Header("GAME SETTINGS")]
        [SerializeField] private GameConfig _config;
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private Transform _bulletTransform;
        [SerializeField] private GameObject _explosionParticle;
        [SerializeField] private GameObject _fireParticle;
        
        private GameStateController _gameState;

        private void Awake()
        {
            _gameState = new GameStateController(_config, _playerTransform, _bulletTransform, _explosionParticle, _fireParticle);
        }

        private void Update()
        {
            _gameState.Tick(Time.deltaTime);
        }
    }
}
