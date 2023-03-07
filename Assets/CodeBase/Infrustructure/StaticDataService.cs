using Assets.CodeBase.Plants;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.CodeBase.Infrustructure
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<PlantType, PlantStaticData> _plants;

        public void Load()
        {
            _plants = Resources.LoadAll<PlantStaticData>("PlantStaticData").ToDictionary(x => x.PlantType, x => x);
        }

        public PlantStaticData GetPlantData(PlantType plantType) =>
            _plants.TryGetValue(plantType, out PlantStaticData plantStaticData)
            ?
            plantStaticData : null;


    }
}
