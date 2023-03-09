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
        private int _maxCapacity;
        private int _currentCapacity;
        private float _plantsFullness => GetReadyPlantCount() / PlantPoints.Count;
        private float _capacityFullness => _currentCapacity / _currentCapacity;

        public int CurrentCapacity => _currentCapacity;


        public void Construct(IGardenFactory factory, int capacity)
        {
            if (PlantPoints.Count == 0)
                CollectPlantPoints();

            PlantPoints.ForEach(x => x.Construct(factory, _plantType));
            _maxCapacity = capacity;
        }

        public void Harvest(int count)
        {
            int lastCurrentCapacity = _currentCapacity;
            _currentCapacity = Mathf.Clamp(_currentCapacity - count, 0, _maxCapacity);
            int countBricksToCreate = lastCurrentCapacity - _currentCapacity;

            CollectPlants();
            CreateBricks(countBricksToCreate);
        }

        private void CreateBricks(int countBricksToCreate)
        {
            for (int i = 0; i < countBricksToCreate; i++)
                _factory.CreatePlantBrick(_plantType, transform.position);
        }

        private void CollectPlantPoints() => 
            PlantPoints = GetComponentsInChildren<PlantPoint>().ToList();

        private int GetReadyPlantCount() => 
            PlantPoints.Where(x => x.IsReadyToCollect == true).ToList().Count;

        private void IncreaseCurrentCapacity()
        {
            if (_plantsFullness > _capacityFullness)
            {
                _currentCapacity++;
                IncreaseCurrentCapacity();
            }
        }

        private void CollectPlants()
        {
            if(_capacityFullness > _plantsFullness)
            {
                PlantPoint point = PlantPoints.FirstOrDefault(x => x.IsReadyToCollect);

                if (point != null)
                {
                    point.CollectPlant();
                    CollectPlants();
                }
            }
        }
    }
}
