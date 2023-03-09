using Assets.CodeBase.Plants;
using UnityEngine;

namespace Assets.CodeBase.GardenTools
{
    public class PlantsCollector : MonoBehaviour
    {
        [SerializeField] private Collider _collider;

        public void EnebleCollider() => 
            _collider.enabled = true;

        public void DisableCollider() =>
            _collider.enabled = false;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IPlant plant))
                plant.Collect();                
        }
    }
}
