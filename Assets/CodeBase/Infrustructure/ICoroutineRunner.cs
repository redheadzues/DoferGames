using System.Collections;
using UnityEngine;

namespace Assets.CodeBase.Infrustructure
{
    public interface ICoroutineRunner : IService
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}
