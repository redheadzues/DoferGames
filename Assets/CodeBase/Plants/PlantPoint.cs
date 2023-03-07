using Assets.CodeBase.Infrustructure.Services;
using UnityEngine;

namespace Assets.CodeBase.Plants
{
    public class PlantPoint : MonoBehaviour
    {
        private bool _isReadyToCollect;
        private IPlant _plant;
        private PlantType _type;
        private GardenFactory _factory;

        public bool IsReadyToCollect => _isReadyToCollect;

        public void Construct(GardenFactory factory, PlantType type)
        {
            _factory = factory;
            _type = type;
            StartGrow();
        }

        public void CollectPlant()
        {
            _plant.Collect();
            _isReadyToCollect = false;
            _plant = null;
            StartGrow();
        }

        private void StartGrow()
        {
            _plant = _factory.CreatePlant(_type);
            _plant.StartGrowOnPoint(transform);
            _plant.GrowFinished += OnGrowFinish;
        }

        private void OnGrowFinish()
        {
            _plant.GrowFinished -= OnGrowFinish;
            _isReadyToCollect = true;
        }
    }
}
