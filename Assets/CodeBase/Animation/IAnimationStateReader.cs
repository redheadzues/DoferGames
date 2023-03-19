using UnityEngine;

namespace Assets.CodeBase.Animation
{
    public interface IAnimationStateReader
    {
        void EnteredState(AnimatorStateInfo stateinfo);
        void ExitedState(AnimatorStateInfo stateinfo);

    }
}