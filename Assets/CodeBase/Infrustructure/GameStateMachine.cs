using Assets.CodeBase.Infrustructure.Services;
using Assets.CodeBase.Infrustructure.States;
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
                [typeof(BootstrapState)] = new BootstrapState(this, services, sceneLoader),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, curtain),
                [typeof(SceneConstructState)] = new SceneConstructState(this, curtain, services.Single<IGardenFactory>(), services.Single<IStaticDataService>()),
                [typeof(GameLoopState)] = new GameLoopState(),

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
}
