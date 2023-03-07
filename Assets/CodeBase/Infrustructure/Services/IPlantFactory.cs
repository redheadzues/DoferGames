using Assets.CodeBase.Plants;

namespace Assets.CodeBase.Infrustructure.Services
{
    public interface IPlantFactory : IService
    {
        IPlant CreatePlant(PlantType plantType);
    }
}
