using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.CodeBase.Plants
{
    public class GardenCell : MonoBehaviour
    {
        [SerializeField] private GameObject _plant;
        [SerializeField] private PlantType _plantType;

        private List<PlantPoint> plantPoints = new List<PlantPoint>();

        private void Awake()
        {
            if(plantPoints.Count == 0)
                plantPoints = GetComponentsInChildren<PlantPoint>().ToList();
        }

        public void Construct(GardenCell factory)
        {
            plantPoints.ForEach(x => x.Construct(this, _plantType));
        }


        public GameObject CreatePlant(PlantType type) =>
            Instantiate(_plant, Vector3.zero, Quaternion.identity);


    }

    public enum PlantType
    {
        Wheat,
    }
}
