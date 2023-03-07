using UnityEngine;

namespace Assets.CodeBase.Infrustructure
{
    public class GameRunner : MonoBehaviour
    {
        public GameBootstraper BootstraperPrefab;

        private void Awake()
        {
            GameBootstraper bootstrapper = FindObjectOfType<GameBootstraper>();

            if (bootstrapper == null)
                Instantiate(BootstraperPrefab);

        }
    }
}
