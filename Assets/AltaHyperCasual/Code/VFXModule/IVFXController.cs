using System;
using UnityEngine;

namespace AltaHyperCasual.Code.VFXModule
{
    public interface IVFXController
    {
        void Initialize(GameObject explosionParticle, GameObject fireParticle);
        void SpawnVFX(VFXType vfxType, Vector3 position);
    }
}
