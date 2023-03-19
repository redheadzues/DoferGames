using DG.Tweening;
using System;
using UnityEngine;

namespace Assets.CodeBase.Plants
{
    public class Plant : MonoBehaviour, IPlantWithConstructor
    {
        private ParticleSystem _collectParticle;
        private ParticleSystem _growParticle;

        private float _growTime;
        private bool _isReadyTocollect;

        public event Action<IPlant> Harvested;

        public void Collect()
        {
            if(_isReadyTocollect == true)
            {
                //Instantiate(_collectParticle);
                Harvested?.Invoke(this);
                Destroy(gameObject);
            }
        }

        public void Construct(ParticleSystem collectParticle, ParticleSystem growParticle, float growTime)
        {
            _collectParticle = collectParticle;
            _growParticle = growParticle;
            _growTime = growTime;
        }

        public void StartGrowOnPoint(Transform parrent)
        {
            transform.SetParent(parrent);
            transform.localPosition = Vector3.zero;            
            Grow();
        }

        private void Grow()
        {
            Vector3 localScale = transform.localScale;

            Sequence growSequence = DOTween.Sequence();

            growSequence.Join(transform.DOScale(0, 0))
                .Join(transform.DOScale(localScale, _growTime))
                .AppendCallback(GrowFinished);
        }

        private void GrowFinished()
        {
            _isReadyTocollect = true;
        }
    }
}
