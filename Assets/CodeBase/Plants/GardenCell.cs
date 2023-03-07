using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.CodeBase.Plants
{
    public class GardenCell : MonoBehaviour
    {
        [SerializeField] private GameObject _plant;
        [SerializeField] private PlantType _plantType;

        public List<PlantPoint> plantPoints = new List<PlantPoint>();


        public void Construct(GardenCell factory)
        {
            if (plantPoints.Count == 0)
                CollectPlantPoints();

            plantPoints.ForEach(x => x.Construct(this, _plantType));
        }

        private void CollectPlantPoints() => 
            plantPoints = GetComponentsInChildren<PlantPoint>().ToList();

        public GameObject CreatePlant(PlantType type) =>
            Instantiate(_plant, Vector3.zero, Quaternion.identity);



    }
}
