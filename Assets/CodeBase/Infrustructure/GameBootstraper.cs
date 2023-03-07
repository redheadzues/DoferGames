using Assets.CodeBase.Infrustructure.Services;
using Assets.CodeBase.Infrustructure.States;
using UnityEngine;

namespace Assets.CodeBase.Infrustructure
{
    public class GameBootstraper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private Curtain _curtainPrefab;

        private Game _game;

        private void Awake()
        {
            _game = new Game(Instantiate(_curtainPrefab), this);
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }

    public class Game
    {
        public GameStateMachine StateMachine;

        public Game(Curtain curtain, ICoroutineRunner coroutineRunner)
        {
            StateMachine = new GameStateMachine(new AllServices(), new SceneLoader(coroutineRunner), curtain);
        }
    }
}
