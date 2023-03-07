using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GardenCell : MonoBehaviour
{
    [SerializeField] private GameObject _plant;
   
    [SerializeField] private List<PlantPoint> plantPoints = new List<PlantPoint>();

    private void Awake()
    {
        plantPoints = GetComponentsInChildren<PlantPoint>().ToList();

        plantPoints.ForEach(x => x.Construct(this));
    }


    public GameObject CreatePlant() => 
        Instantiate(_plant, Vector3.zero, Quaternion.identity);


}
