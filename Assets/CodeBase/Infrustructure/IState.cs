namespace Assets.CodeBase.Infrustructure
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
