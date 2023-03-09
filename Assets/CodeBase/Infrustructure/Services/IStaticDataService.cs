using Assets.CodeBase.Infrustructure.StaticData;
using Assets.CodeBase.Plants;

namespace Assets.CodeBase.Infrustructure.Services
{
    public interface IStaticDataService : IService
    {
        void Load();
        PlantStaticData GetPlantData(PlantType plantType);
        GardenCellData GetGardenCell(PlantType plantType);
        SceneStaticData GetSceneData();
    }
}
