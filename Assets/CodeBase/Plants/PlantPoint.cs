using UnityEngine;

public class PlantPoint : MonoBehaviour
{
    private bool _isReadyToCollect;
    private IPlant _plant;
    private GardenCell _factory;

    public bool IsReadyToCollect => _isReadyToCollect;

    public void Construct(GardenCell factory)
    {
        _factory = factory;
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
        GameObject plant = _factory.CreatePlant();
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
