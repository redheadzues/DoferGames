using Assets.CodeBase.Infrustructure.Services;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.CodeBase.Plants
{
    public class GardenCell : MonoBehaviour
    {
        [SerializeField] private PlantType _plantType;

        public List<PlantPoint> PlantPoints = new List<PlantPoint>();

        private IGardenFactory _factory;
        private int _countHarvestedForReward;
        private int _currentHarvested;

        public void Construct(IGardenFactory factory, int capacity)
        {
            if (PlantPoints.Count == 0)
                CollectPlantPoints();

            _factory = factory;

            PlantPoints.ForEach(x => x.Construct(_factory, _plantType));

            _countHarvestedForReward = PlantPoints.Count / capacity;
        }

        private void OnEnable() => 
            PlantPoints.ForEach(x => x.Harvested += OnHarvested);

        private void OnDisable() => 
            PlantPoints.ForEach(x => x.Harvested -= OnHarvested);

        private void OnHarvested()
        {
            _currentHarvested++;

            if (_currentHarvested == _countHarvestedForReward)
            {
                CreateBrick();
                _currentHarvested = 0;
            }
        }

        private void CreateBrick() => 
            _factory.CreatePlantBrick(_plantType, transform.position);

        private void CollectPlantPoints() => 
            PlantPoints = GetComponentsInChildren<PlantPoint>().ToList();

    }
}
