using Assets.CodeBase.Animation;
using Assets.CodeBase.GardenTools;
using Assets.CodeBase.Plants;
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
            _reciver.MoveStarted += OnMoveStarted;
            _reciver.MoveFinished += OnMoveFinished;
            _tool.gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            _harvestZone.TriggerEnter -= OnHarvestZoneEnter;
            _reciver.CollectStarted -= OnCollectStarted;
            _reciver.CollectFinished -= OnCollectFinished;
            _reciver.MoveStarted -= OnMoveStarted;
            _reciver.MoveFinished -= OnMoveFinished;
        }

        private void OnMoveStarted()
        {
            _harvestZone.gameObject.SetActive(false);
            OnCollectFinished();
        }

        private void OnMoveFinished()
        {
            _harvestZone.gameObject.SetActive(true);
        }

        private void OnHarvestZoneEnter(Collider collider)
        {
            if(collider.TryGetComponent(out IPlant plant))
            {
                _harvestZone.gameObject.SetActive(false);
                _tool.gameObject.SetActive(true);
                _characterAnimator.Harvest();
            }
        }

        private void OnCollectStarted()
        {
            _tool.EnebleCollider();
        }

        private void OnCollectFinished()
        {
            _tool.DisableCollider();
            _tool.gameObject.SetActive(false);
        }
    }
}
