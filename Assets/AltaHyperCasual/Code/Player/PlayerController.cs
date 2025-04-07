using UnityEngine;

namespace AltaHyperCasual.Code.Player
{
    public class PlayerController : IPlayer
    {
        private Transform _transform;
        
        public void Initialize(Transform transform, float playerRadius)
        {
            _transform = transform;
            SetSize(playerRadius);
        }
        
        public void SetSize(float radius)
        {
            _transform.localScale = new Vector3(radius, radius, radius);
        }

        public void MoveTowards(Vector3 target)
        {
            
        }
    }
}