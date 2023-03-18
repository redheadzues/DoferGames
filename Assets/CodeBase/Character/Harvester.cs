using Assets.CodeBase.GardenTools;
using System;
using UnityEngine;

namespace Assets.CodeBase.Character
{
    public class Harvester : MonoBehaviour
    {
        [SerializeField] private CharacterAnimator _characterAnimator;
        [SerializeField] private TriggerObserver _harvestZone;
        [SerializeField] private PlantsCollector _tool;
        [SerializeField] private AnimationEventReciver _reciver;


        private void OnEnable()
        {
            _harvestZone.TriggerEnter += OnHarvestZoneEnter;
            _reciver.CollectStarted += OnCollectStarted;
            _reciver.CollectFinished += OnCollectFinished;
            _characterAnimator.MoveStarted += OnCollectFinished;
            _tool.gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            _harvestZone.TriggerEnter -= OnHarvestZoneEnter;
            _reciver.CollectStarted -= OnCollectStarted;
            _reciver.CollectFinished -= OnCollectFinished;
            _characterAnimator.MoveStarted -= OnCollectFinished;
        }


        private void OnHarvestZoneEnter(Collider collider)
        {
            _harvestZone.gameObject.SetActive(false);
            _tool.gameObject.SetActive(true);
            transform.LookAt(collider.transform.position);
            _characterAnimator.Harvest();
        }

        public void OnCollectStarted()
        {
            _tool.EnebleCollider();
        }

        public void OnCollectFinished()
        {
            _tool.DisableCollider();
            _tool.gameObject.SetActive(false);
            _harvestZone.gameObject.SetActive(true);
        }
    }
}
