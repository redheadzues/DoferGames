using System;
using UnityEngine;

public interface IPlant
{
    event Action GrowFinished;
    void Collect();
    void StartGrowOnPoint(Transform parrent);
}
