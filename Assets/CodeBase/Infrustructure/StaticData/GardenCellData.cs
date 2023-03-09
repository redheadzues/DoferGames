using Assets.CodeBase.Plants;
using System;
using UnityEngine;

namespace Assets.CodeBase.Infrustructure.StaticData
{
    [Serializable]
    public class GardenCellData
    {
        public PlantType PlantType;
        public GardenCell Template;
        [Range(0,20)]public int Capacity;
    }
}
