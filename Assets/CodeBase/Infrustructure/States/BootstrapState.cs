using Assets.CodeBase.Infrustructure.Services;

namespace Assets.CodeBase.Infrustructure.States
{
    public class BootstrapState : ISimpleState
    {
        private const string InitialScene = "InitialScene";
        private const string DemoScene = "DemoScene";
        private readonly GameStateMachine _gameStateMachine;
        private readonly AllServices _services;
        private readonly SceneLoader _sceneLoader;

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
            _gameStateMachine.Enter<LoadLevelState, string>(DemoScene);
        }

        private void RegisterStaticData()
        {
            IStaticDataService staticData = new StaticDataService();
            staticData.Load();
            _services.RegisterSingle(staticData);
        }
    }
}
