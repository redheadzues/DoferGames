using Assets.CodeBase.Plants;
using UnityEngine;

public class GardenCellMarker : MonoBehaviour
{
    [SerializeField] private PlantType _type;

    public PlantType PlantType => _type;

}
