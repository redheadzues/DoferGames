using System;
using System.Collections.Generic;

namespace Assets.CodeBase.Infrustructure
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public GameStateMachine(AllServices services, SceneLoader sceneLoader, Curtain curtain)
        {
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, services),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, curtain),
            };
        }

        public void Enter<TState>() where TState : class, ISimpleState
        {
            ISimpleState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayLoad>(TPayLoad payload) where TState : class, IPayLoadedState<TPayLoad>
        {
            IPayLoadedState<TPayLoad> state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState
        {
            return _states[typeof(TState)] as TState;
        }
    }

    public class LoadLevelState : IPayLoadedState<string>
    {
        private GameStateMachine _gameStateMachine;
        private SceneLoader _sceneLoader;
        private Curtain _curtain;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, Curtain curtain)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
        }

        public void Enter(string sceneName)
        {
            _curtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {

        }

        private void OnLoaded()
        {

        }
    }

    public class BootstrapState : ISimpleState
    {
        private GameStateMachine _gameStateMachine;
        private AllServices _services;

        public BootstrapState(GameStateMachine gameStateMachine, AllServices services)
        {
            _gameStateMachine = gameStateMachine;
            _services = services;
            RegisterServices();
        }

        private void RegisterServices()
        {
            RegisterStaticData();
            _services.RegisterSingle<IPlantFactory>(new PlantsFactory(_services.Single<IStaticDataService>()));
        }

        public void Enter()
        {
            
        }

        public void Exit()
        {
            
        }

        private void RegisterStaticData()
        {
            IStaticDataService staticData = new StaticDataService();
            staticData.Load();
            _services.RegisterSingle(staticData);
        }
    }
}
