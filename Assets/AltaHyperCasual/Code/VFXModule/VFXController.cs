using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AltaHyperCasual.Code.VFXModule
{
    public class VFXController : IVFXController
    {
        private GameObject _explosionParticle;
        private GameObject _fireParticle;

        public void Initialize(GameObject explosionParticle, GameObject fireParticle)
        {
            _explosionParticle = explosionParticle;
            _fireParticle = fireParticle;
        }

        public void SpawnVFX(VFXType vfxType, Vector3 position)
        {
            Object.Instantiate(GetParticle(vfxType), position, quaternion.identity);
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
