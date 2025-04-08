using UnityEngine;

namespace AltaHyperCasual.Code.Configs
{
    [CreateAssetMenu(fileName = "New Config", menuName = "Configs/Game Config")]
    public class GameConfig : ScriptableObject
    {
        [Header("PLAYER SETTINGS")]
        [SerializeField] private float _playerRadius;
        [Header("JELLY ANIMATION SETTINGS")]
        [Header("default:  5")]
        [SerializeField] private float _deformSpeed;
        [Header("default:  0.1")]
        [SerializeField] private float _deformAmount;
        [Header("default:  2")]
        [SerializeField] private float _scaleSpeed; 
        
        public float PlayerRadius => _playerRadius;
        public float DeformSpeed => _deformSpeed;
        public float DeformAmount => _deformAmount;
        public float ScaleSpeed => _scaleSpeed;
    }
}
