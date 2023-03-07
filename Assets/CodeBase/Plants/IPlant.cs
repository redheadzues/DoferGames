using System;
using UnityEngine;

namespace Assets.CodeBase.Plants
{
    public interface IPlant
    {
        event Action GrowFinished;
        void Collect();
        void StartGrowOnPoint(Transform parrent);
    }

    public interface IPlantWithConstructor : IPlant
    {
        void Construct(ParticleSystem collectParticle, ParticleSystem growParticle, float growTime);
    }
}
