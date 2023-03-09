using Assets.CodeBase.Infrustructure.StaticData;
using Assets.CodeBase.Plants;
using UnityEngine;

namespace Assets.CodeBase.Infrustructure.Services
{
    public class GardenFactory : IGardenFactory
    {
        private IStaticDataService _staticData;

        public GardenFactory(IStaticDataService staticDataService)
        {
            _staticData = staticDataService;
        }

        public IPlant CreatePlant(PlantType plantType)
        {
            PlantStaticData plantStaticData = _staticData.GetPlantData(plantType);

            GameObject template = Object.Instantiate(plantStaticData.Template);

            IPlantWithConstructor plant = template.GetComponent<IPlantWithConstructor>();
            plant.Construct(plantStaticData.CollectParticle, plantStaticData.GrowParticle, plantStaticData.GrowTime);

            return plant;
        }

        public void CreateGardenCell(PlantType plantType, Vector3 point)
        {
            GardenCellData cellData = _staticData.GetGardenCell(plantType);

            GardenCell gardenCell = Object.Instantiate(cellData.Template, point, Quaternion.identity);

            gardenCell.Construct(this, cellData.Capacity);
        }

        public void CreatePlantBrick(PlantType plantType, Vector3 position)
        {

        }
    }
}
