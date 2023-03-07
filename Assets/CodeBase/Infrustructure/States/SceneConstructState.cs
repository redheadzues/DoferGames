using Assets.CodeBase.Infrustructure.Services;
using Assets.CodeBase.Infrustructure.StaticData;

namespace Assets.CodeBase.Infrustructure.States
{
    public class SceneConstructState : ISimpleState
    {
        private readonly Curtain _curtain;
        private readonly IGardenFactory _gardenFactory;
        private readonly GameStateMachine _gameStateMachine;
        private readonly IStaticDataService _staticData;


        public SceneConstructState(GameStateMachine gameStateMachine, Curtain curtain, IGardenFactory gardenFactory, IStaticDataService staticData)
        {
            _curtain = curtain;
            _gardenFactory = gardenFactory;
            _gameStateMachine = gameStateMachine;
            _staticData = staticData;
        }

        public void Enter()
        {
            SceneStaticData sceneData = _staticData.GetSceneData();
            sceneData.SceneGardenCells.ForEach(x => _gardenFactory.CreateGardenCell(x.PlantType, x.Position));


            _gameStateMachine.Enter<GameLoopState>();
        }

        public void Exit()
        {
            _curtain.Hide();
        }
    }
}
