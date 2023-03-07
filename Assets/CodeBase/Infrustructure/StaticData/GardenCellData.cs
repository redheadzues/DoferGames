using Assets.CodeBase.Plants;
using System;
using UnityEngine;

namespace Assets.CodeBase.Infrustructure.StaticData
{
    [Serializable]
    public class GardenCellData
    {
        public PlantType PlantType;
        public GameObject CellTemplate;
    }
}
