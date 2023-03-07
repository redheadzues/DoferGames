using Assets.CodeBase.Infrustructure.StaticData;
using Assets.CodeBase.Plants;
using UnityEngine;

namespace Assets.CodeBase.Infrustructure.Services
{
    public interface IStaticDataService : IService
    {
        void Load();
        PlantStaticData GetPlantData(PlantType plantType);
        GameObject GetGardenCell(PlantType plantType);
        SceneStaticData GetSceneData();
    }
}
