using UnityEngine;

namespace AltaHyperCasual.Code.Configs
{
    [CreateAssetMenu(fileName = "New Config", menuName = "Configs/Game Config")]
    public class GameConfig : ScriptableObject
    {
        [Header("PLAYER SETTINGS")]
        [SerializeField] private float _playerRadius;
        [SerializeField] private float _playerMoveSpeed;
        [SerializeField] private float _bulletMoveSpeed;
        [Header("JELLY ANIMATION SETTINGS")]
        [Header("default:  5")]
        [SerializeField] private float _deformSpeed;
        [Header("default:  0.1")]
        [SerializeField] private float _deformAmount;
        [Header("default:  2")]
        [SerializeField] private float _scaleSpeed; 
        [Header("PARTICLES SETTINGS")]
        [SerializeField] private int _maxParticlesAmount; 

        public float PlayerRadius => _playerRadius;
        public float PlayerMoveSpeed => _playerMoveSpeed;
        public float BulletMoveSpeed => _bulletMoveSpeed;
        public float DeformSpeed => _deformSpeed;
        public float DeformAmount => _deformAmount;
        public float ScaleSpeed => _scaleSpeed;
        public int MaxParticlesAmount => _maxParticlesAmount;
    }
}
