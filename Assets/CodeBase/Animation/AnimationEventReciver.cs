using System;
using UnityEngine;

namespace Assets.CodeBase.Animation
{
    public class AnimationEventReciver : MonoBehaviour, IAnimationStateReader
    {
        private const string FastRun = "FastRun";

        public event Action CollectStarted;
        public event Action CollectFinished;

        public event Action MoveStarted;
        public event Action MoveFinished;

        public void StartCollect() =>
            CollectStarted?.Invoke();

        public void FinishCollect() =>
            CollectFinished?.Invoke();

        public void EnteredState(AnimatorStateInfo stateinfo)
        {
            if (stateinfo.IsName(FastRun))
                MoveStarted?.Invoke();
        }

        public void ExitedState(AnimatorStateInfo stateinfo)
        {
            if (stateinfo.IsName(FastRun))
                MoveFinished?.Invoke();
        }
    }
}
