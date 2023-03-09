using System;
using UnityEngine;

namespace Assets.CodeBase.Character
{
    public class AnimationEventReciver : MonoBehaviour
    {
        public event Action CollectStarted;
        public event Action CollectFinished;

        public void StartCollect() => 
            CollectStarted?.Invoke();

        public void FinishCollect() =>
            CollectFinished?.Invoke();
    }
}
