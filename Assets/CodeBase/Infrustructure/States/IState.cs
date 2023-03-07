namespace Assets.CodeBase.Infrustructure.States
{
    public interface IExitableState
    {
        void Exit();
    }

    public interface ISimpleState : IExitableState
    {
        void Enter();
    }

    public interface IPayLoadedState<TPayLoad> : IExitableState
    {
        void Enter(TPayLoad payLoad);
    }
}
