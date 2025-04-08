using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AltaHyperCasual.Code.VFXModule
{
    public class VFXController : IVFXController
    {
        
        private int _maxParticleAmount;
        
        private GameObject _explosionParticle;
        private GameObject _fireParticle;

        private Queue<GameObject> _fireQueue;

        public void Initialize(int maxParticlesAmount, GameObject explosionParticle, GameObject fireParticle)
        {
            _maxParticleAmount = maxParticlesAmount;
            _fireQueue = new Queue<GameObject>(_maxParticleAmount);

            _explosionParticle = explosionParticle;
            _fireParticle = fireParticle;
        }

        public void SpawnVFX(VFXType vfxType, Vector3 position)
        {
            if (_fireQueue.Count >= _maxParticleAmount)
            {
                _fireQueue.Peek().SetActive(false);
                _fireQueue.Dequeue();
            }

            GameObject particle = Object.Instantiate(GetParticle(vfxType), position, quaternion.identity);
            _fireQueue.Enqueue(particle);
        }

        private GameObject GetParticle(VFXType vfxType)
        {
            switch (vfxType)
            {
                case VFXType.Explosion:
                    return _explosionParticle;
                case VFXType.Fire:
                    return _fireParticle;
                default:
                    return null;
            }
        }
    }
}
