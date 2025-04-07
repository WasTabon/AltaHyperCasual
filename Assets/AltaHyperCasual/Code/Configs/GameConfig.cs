using UnityEngine;

namespace AltaHyperCasual.Code.Configs
{
    [CreateAssetMenu(fileName = "New Config", menuName = "Configs/Game Config")]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private float _playerRadius;
        
        public float PlayerRadius => _playerRadius;
    }
}
