namespace Assets.CodeBase.Infrustructure.States
{
    public class SceneConstructState : ISimpleState
    {
        private Curtain _curtain;
        private GameStateMachine _gameStateMachine;

        public SceneConstructState(GameStateMachine gameStateMachine, Curtain curtain)
        {
            _curtain = curtain;
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            _gameStateMachine.Enter<GameLoopState>();
        }

        public void Exit()
        {
            _curtain.Hide();
        }
    }
}
