using Assets.CodeBase.Infrustructure.Services;
using System;
using UnityEngine;

namespace Assets.CodeBase.Plants
{
    public class PlantPoint : MonoBehaviour
    {
        private IPlant _plant;
        private PlantType _type;
        private IGardenFactory _factory;

        public event Action Harvested;

        public void Construct(IGardenFactory factory, PlantType type)
        {
            _factory = factory;
            _type = type;
            StartGrow();
        }

        private void StartGrow()
        {
            _plant = _factory.CreatePlant(_type);
            _plant.StartGrowOnPoint(transform);
            _plant.Harvested += OnHarvested;
        }

        private void OnHarvested(IPlant plant)
        {
            plant.Harvested -= OnHarvested;
            Harvested?.Invoke();
            StartGrow();
        }
    }
}
