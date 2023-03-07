namespace Assets.CodeBase.Infrustructure
{
    public class PlantsFactory : IPlantFactory
    {
        private IStaticDataService _staticData;

        public PlantsFactory(IStaticDataService staticDataService)
        {
            _staticData = staticDataService;
        }

        public void CreatePlant()
        {
            
        }
    }
}
