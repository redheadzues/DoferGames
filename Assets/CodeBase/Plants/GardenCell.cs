using Assets.CodeBase.Infrustructure.Services;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.CodeBase.Plants
{
    public class GardenCell : MonoBehaviour
    {
        [SerializeField] private PlantType _plantType;

        public List<PlantPoint> plantPoints = new List<PlantPoint>();

        public void Construct(GardenFactory factory)
        {
            if (plantPoints.Count == 0)
                CollectPlantPoints();

            plantPoints.ForEach(x => x.Construct(factory, _plantType));
        }

        private void CollectPlantPoints() => 
            plantPoints = GetComponentsInChildren<PlantPoint>().ToList();

    }
}
