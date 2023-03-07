namespace Assets.CodeBase.Infrustructure
{
    public class BootstrapState : ISimpleState
    {
        private const string InitialScene = "InitialScene";
        private GameStateMachine _gameStateMachine;
        private AllServices _services;
        private SceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine gameStateMachine, AllServices services, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _services = services;
            _sceneLoader = sceneLoader;
            RegisterServices();
        }

        private void RegisterServices()
        {
            RegisterStaticData();
            _services.RegisterSingle<IPlantFactory>(new PlantsFactory(_services.Single<IStaticDataService>()));
        }

        public void Enter()
        {
            _sceneLoader.Load(InitialScene, OnLevelLoaded);
        }


        public void Exit()
        {
            
        }
        private void OnLevelLoaded()
        {
            _gameStateMachine.Enter<SceneConstructState>();
        }

        private void RegisterStaticData()
        {
            IStaticDataService staticData = new StaticDataService();
            staticData.Load();
            _services.RegisterSingle(staticData);
        }
    }
}
