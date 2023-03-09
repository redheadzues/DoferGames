using Assets.CodeBase.Plants;
using UnityEngine;

namespace Assets.CodeBase.Infrustructure.Services
{
    public interface IGardenFactory : IService
    {
        void CreateGardenCell(PlantType plantType, Vector3 point);
        IPlant CreatePlant(PlantType plantType);
        void CreatePlantBrick(PlantType plantType, Vector3 position);
    }
}
