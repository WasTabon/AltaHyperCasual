using AltaHyperCasual.Code.Animations.JellyAnimation;
using AltaHyperCasual.Code.Configs;
using AltaHyperCasual.Code.Input;
using AltaHyperCasual.Code.Player;
using AltaHyperCasual.Code.VFXModule;
using AltaHyperCasual.Utils.Updatable;
using UnityEngine;

namespace AltaHyperCasual.Code.Core
{
    public class GameStateController : IUpdatable
    {
        private readonly GameConfig _config;
        private readonly IPlayer _player;
        private readonly IJellyAnimation _jellyAnimationPlayer;
        private readonly IJellyAnimation _jellyAnimationBullet;
        private readonly IInputController _inputController;
        private readonly IBullet _bullet;
        private readonly IVFXController _vfxController;

        private GameStateType _gameState;

        public GameStateController(GameConfig config, Transform playerTransform, Transform bulletTransform, GameObject explosionParticle, GameObject fireParticle)
        {
            _config = config;
            
            _inputController = new InputController();
            
            _jellyAnimationPlayer = new JellyAnimationController(playerTransform, config.DeformSpeed, config.DeformAmount, config.ScaleSpeed);
            _jellyAnimationBullet = new JellyAnimationController(bulletTransform, config.DeformSpeed, config.DeformAmount, config.ScaleSpeed);

            _vfxController = new VFXController();
            _vfxController.Initialize(config.MaxParticlesAmount, explosionParticle, fireParticle);

            _player = new PlayerController();
            _player.Initialize(playerTransform, config.PlayerRadius, _jellyAnimationPlayer, _config.PlayerSizeDecreaseSpeed, _config.PlayerMoveSpeed);
            _inputController.OnHoldInvoke += _player.HandleShootStart;
            _inputController.OnHoldEnd += _player.HandleShootEnd;

            _bullet = new Bullet();
            _bullet.Initialize(config.BulletMoveSpeed ,bulletTransform, _jellyAnimationBullet, _vfxController, _config.PlayerSizeDecreaseSpeed);
            _inputController.OnHoldStart += _bullet.HandleShootStart;
            _inputController.OnHoldInvoke += _bullet.HandleShootHold;
            _inputController.OnHoldEnd += _bullet.HandleShootEnd;

            _bullet.OnMoveStart += SetStateShot;
            _bullet.OnMoveEnd += SetStateIdle;
        }

        public void Tick(float deltaTime)
        {
            _inputController.Tick(deltaTime);
            _player.Tick(deltaTime);
            _bullet.Tick(deltaTime);
        }

        private void SetStateIdle()
        {
            _gameState = GameStateType.Idle;
            ChangeGameSettings();
        }
        private void SetStateShot()
        {
            _gameState = GameStateType.Shot;
            ChangeGameSettings();
        }

        private void ChangeGameSettings()
        {
            Debug.Log($"Current state: {_gameState}");
            if (_gameState == GameStateType.Idle)
            {
                _inputController.OnHoldInvoke += _player.HandleShootStart;
                _inputController.OnHoldEnd += _player.HandleShootEnd;
            
                _inputController.OnHoldStart += _bullet.HandleShootStart;
                _inputController.OnHoldInvoke += _bullet.HandleShootHold;
                _inputController.OnHoldEnd += _bullet.HandleShootEnd;
            }
            else if (_gameState == GameStateType.Shot)
            {
                _inputController.OnHoldInvoke -= _player.HandleShootStart;
                _inputController.OnHoldEnd -= _player.HandleShootEnd;
            
                _inputController.OnHoldStart -= _bullet.HandleShootStart;
                _inputController.OnHoldInvoke -= _bullet.HandleShootHold;
                _inputController.OnHoldEnd -= _bullet.HandleShootEnd;
            }
        }
    }
}
