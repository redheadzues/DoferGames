using UnityEngine;

namespace Assets.CodeBase.Plants
{
    public class PlantPoint : MonoBehaviour
    {
        private bool _isReadyToCollect;
        private IPlant _plant;
        private PlantType _type;
        private GardenCell _factory;

        public bool IsReadyToCollect => _isReadyToCollect;

        public void Construct(GardenCell factory, PlantType type)
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
            GameObject plant = _factory.CreatePlant(_type);
            _plant = plant.GetComponent<IPlant>();
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
