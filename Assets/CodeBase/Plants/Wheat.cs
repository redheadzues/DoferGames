using System;
using UnityEngine;

namespace Assets.CodeBase.Plants
{
    public class Wheat : MonoBehaviour, IPlant
    {
        [SerializeField] private ParticleSystem _collectParticle;
        [SerializeField] private ParticleSystem _growParticle;

        public event Action GrowFinished;

        public void Collect()
        {
            Instantiate(_collectParticle);
            Destroy(gameObject);
        }

        public void StartGrowOnPoint(Transform parrent)
        {
            transform.SetParent(parrent);
            transform.localPosition = Vector3.zero;
        }
    }
}
