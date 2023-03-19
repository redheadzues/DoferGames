using UnityEngine;

namespace Assets.CodeBase.Animation
{
    public class AnimatorStateReporter : StateMachineBehaviour
    {
        private IAnimationStateReader _stateReader;

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateExit(animator, stateInfo, layerIndex);
            FindReader(animator);

            _stateReader.ExitedState(stateInfo);
        }

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            FindReader(animator);

            _stateReader.EnteredState(stateInfo);
        }

        private void FindReader(Animator animator)
        {
            if (_stateReader == null)
                if (animator.TryGetComponent(out IAnimationStateReader reader))
                    _stateReader = reader;
        }
    }
}