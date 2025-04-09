using AltaHyperCasual.Code.Configs;
using AltaHyperCasual.Code.UI;
using UnityEngine;

namespace AltaHyperCasual.Code.Core
{
    public class Bootstrap : MonoBehaviour
    {
        [Header("GAME SETTINGS")]
        [SerializeField] private GameConfig _config;
        [SerializeField] private UIController _uiController;
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private Transform _cameraTransform;
        [SerializeField] private Transform _finishTransform;
        [SerializeField] private Transform _bulletTransform;
        [SerializeField] private GameObject _explosionParticle;
        [SerializeField] private GameObject _fireParticle;
        
        private GameStateController _gameState;

        private void Awake()
        {
            _gameState = new GameStateController(_config, _uiController, _playerTransform, _cameraTransform, _finishTransform, _bulletTransform, _explosionParticle, _fireParticle);
        }

        private void Update()
        {
            _gameState.Tick(Time.deltaTime);
        }
    }
}
