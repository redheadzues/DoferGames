using Assets.CodeBase.Plants;

namespace Assets.CodeBase.Infrustructure
{
    public interface IStaticDataService : IService
    {
        void Load();
        PlantStaticData GetPlantData(PlantType plantType);
    }
}
