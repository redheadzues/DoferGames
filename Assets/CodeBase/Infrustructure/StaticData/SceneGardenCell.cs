using Assets.CodeBase.Plants;
using System;
using UnityEngine;

namespace Assets.CodeBase.Infrustructure.StaticData
{
    [Serializable]
    public class SceneGardenCell
    {
        public Vector3 Position;
        public PlantType PlantType;

        public SceneGardenCell(Vector3 position, PlantType plantType)
        {
            Position = position;
            PlantType = plantType;
        }
    }
}
