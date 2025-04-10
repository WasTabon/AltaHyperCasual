using AltaHyperCasual.Code.Animations.JellyAnimation;
using AltaHyperCasual.Code.Camera;
using AltaHyperCasual.Code.Configs;
using AltaHyperCasual.Code.Input;
using AltaHyperCasual.Code.Player;
using AltaHyperCasual.Code.UI;
using AltaHyperCasual.Code.VFXModule;
using AltaHyperCasual.Code.WinController;
using AltaHyperCasual.Utils.Updatable;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AltaHyperCasual.Code.Core
{
    public class GameStateController : IUpdatable
    {
        private readonly GameConfig _config;
        private readonly UIController _uiController;
        private readonly IPlayer _player;
        private readonly IJellyAnimation _jellyAnimationPlayer;
        private readonly IJellyAnimation _jellyAnimationBullet;
        private readonly IInputController _inputController;
        private readonly IBullet _bullet;
        private readonly IVFXController _vfxController;
        private readonly ICamera _camera;
        private readonly IWin _winController;

        private GameStateType _gameState;
        private GameStateType _previousState;

        public GameStateController(GameConfig config, UIController uiController, Transform playerTransform, Transform cameraTransform, Transform finishTransform, Transform bulletTransform, GameObject explosionParticle, GameObject fireParticle)
        {
            _config = config;
            _uiController = uiController;
            
            _inputController = new InputController();
            
            _jellyAnimationPlayer = new JellyAnimationController(playerTransform, config.DeformSpeed, config.DeformAmount, config.ScaleSpeed);
            _jellyAnimationBullet = new JellyAnimationController(bulletTransform, config.DeformSpeed, config.DeformAmount, config.ScaleSpeed);

            _vfxController = new VFXController();
            _vfxController.Initialize(explosionParticle, fireParticle);

            _player = new PlayerController();
            _player.Initialize(playerTransform, config.PlayerRadius, _jellyAnimationPlayer, _config.PlayerSizeDecreaseSpeed, _config.PlayerMoveSpeed);

            _bullet = new Bullet();
            _bullet.Initialize(config.BulletMoveSpeed ,bulletTransform, _jellyAnimationBullet, _vfxController, _config.PlayerSizeDecreaseSpeed);

            _camera = new CameraController();
            _camera.Initialize(cameraTransform, playerTransform);

            _winController = new WinController.WinController();
            _winController.Initialize(playerTransform, finishTransform);

            _uiController.OnPause += SetStatePause;
            _uiController.OnContinue += SetStateContinue;
            _uiController.OnRestart += RestartGame;
            
            _inputController.OnHoldInvoke += _player.HandleShootStart;
            _player.OnMoveToPoint += SetStateMoving;
            _player.OnStop += SetStateIdle;
            
            _inputController.OnHoldStart += _bullet.HandleShootStart;
            _inputController.OnHoldInvoke += _bullet.HandleShootHold;
            _inputController.OnHoldEnd += _bullet.HandleShootEnd;
            
            _bullet.OnMoveStart += SetStateShot;
            _bullet.OnMoveEnd += _player.HandleShootEnd;

            _winController.OnWin += SetStateWin;
            _winController.OnLose += SetStateLose;
            
            SetStateIdle();
        }

        public void Tick(float deltaTime)
        {
            if (_gameState == GameStateType.Pause)
                return;
            
            if (_gameState != GameStateType.Win && _gameState != GameStateType.Lose)
            {
                _inputController.Tick(deltaTime);
                _player.Tick(deltaTime);
                _bullet.Tick(deltaTime);
                _winController.CheckLose();
                _camera.Tick(deltaTime);
            }
            if (_gameState == GameStateType.Moving)
            {
                _winController.CheckWin();
            }   
        }

        private void SetStatePause()
        {
            _previousState = _gameState;
            _gameState = GameStateType.Pause;
            ChangeGameSettings();
        }
        private void SetStateContinue()
        {
            _gameState = _previousState;
            ChangeGameSettings();
        }
        private void SetStateIdle()
        {
            _gameState = GameStateType.Idle;
            ChangeGameSettings();
        }
        private void SetStateMoving()
        {
            _gameState = GameStateType.Moving;
            ChangeGameSettings();
        }
        private void SetStateShot()
        {
            _gameState = GameStateType.Shot;
            ChangeGameSettings();
        }
        private void SetStateLose()
        {
            _gameState = GameStateType.Lose;
            ChangeGameSettings();
        }
        private void SetStateWin()
        {
            _gameState = GameStateType.Win;
            ChangeGameSettings();
        }

        private void RestartGame()
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }

        private void ChangeGameSettings()
        {
            Debug.Log($"Current state: {_gameState}");
            if (_gameState == GameStateType.Pause)
            {
                UnsubscribeAll();
            }
            else if (_gameState == GameStateType.Idle)
            {
                SubscribeAll();
            }
            else if (_gameState == GameStateType.Shot)
            {
                UnsubscribeAll();
            }
            else if (_gameState == GameStateType.Moving)
            {

            }
            else if (_gameState == GameStateType.Lose)
            {
                _uiController.ShowLosePanel();
            }
            else if (_gameState == GameStateType.Win)
            {
                _uiController.ShowWinPanel();
            }
        }

        private void SubscribeAll()
        {
            _inputController.OnHoldInvoke += _player.HandleShootStart;
            
            _inputController.OnHoldStart += _bullet.HandleShootStart;
            _inputController.OnHoldInvoke += _bullet.HandleShootHold;
            _inputController.OnHoldEnd += _bullet.HandleShootEnd;
        }

        private void UnsubscribeAll()
        {
            _inputController.OnHoldInvoke -= _player.HandleShootStart;
            
            _inputController.OnHoldStart -= _bullet.HandleShootStart;
            _inputController.OnHoldInvoke -= _bullet.HandleShootHold;
            _inputController.OnHoldEnd -= _bullet.HandleShootEnd;
        }
    }
}
