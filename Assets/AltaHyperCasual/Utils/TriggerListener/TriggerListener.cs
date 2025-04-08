using System;
using UnityEngine;

namespace AltaHyperCasual.Utils.TriggerListener
{
    [RequireComponent(typeof(Collider))]
    public class TriggerListener : MonoBehaviour
    {
        public event Action<Collider> OnTriggerEnterEvent;
        public event Action<Collider> OnTriggerExitEvent;

        private string _collisionTag;

        public void SetCollisionTag(string tag)
        {
            _collisionTag = tag;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            OnTriggerEnterEvent?.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            OnTriggerExitEvent?.Invoke(other);
        }
    }
}