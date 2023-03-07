using Assets.CodeBase.Plants;
using UnityEngine;

namespace Assets.CodeBase.Infrustructure.Services
{
    public class PlantsFactory : IPlantFactory
    {
        private IStaticDataService _staticData;

        public PlantsFactory(IStaticDataService staticDataService)
        {
            _staticData = staticDataService;
        }

        public IPlant CreatePlant(PlantType plantType)
        {
            PlantStaticData plantStaticData = _staticData.GetPlantData(plantType);

            GameObject template = Object.Instantiate(plantStaticData.Template);

            IPlant plant = template.GetComponent<IPlant>();

            return plant;
        }
    }
}
