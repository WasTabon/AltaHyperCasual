using UnityEngine;

namespace AltaHyperCasual.Code.VFXModule
{
    public interface IVFXController
    {
        void Initialize(int maxParticlesAmount, GameObject explosionParticle, GameObject fireParticle);
        void SpawnVFX(VFXType vfxType, Vector3 position);
    }
}
