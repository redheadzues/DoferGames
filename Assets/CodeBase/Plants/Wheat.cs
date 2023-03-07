﻿using DG.Tweening;
using System;
using UnityEngine;

namespace Assets.CodeBase.Plants
{
    public class Wheat : MonoBehaviour, IPlant
    {
        [SerializeField] private ParticleSystem _collectParticle;
        [SerializeField] private ParticleSystem _growParticle;

        private float _growTime = 10f;

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
            Grow();
        }

        private void Grow()
        {
            Vector3 localScale = transform.localScale;

            var growSequence = DOTween.Sequence();

            growSequence.Join(transform.DOScale(0, 0))
                .Join(transform.DOScale(localScale, _growTime))
                .AppendCallback(() => GrowFinished.Invoke());;
        }
    }
}
