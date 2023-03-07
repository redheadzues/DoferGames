using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.Infrustructure.StaticData
{
    [CreateAssetMenu(fileName = "SceneStaticData", menuName = "StaticData/SceneStaticDtata")]
    public class SceneStaticData : ScriptableObject
    {
        [HideInInspector] public string SceneKey;
        public List<SceneGardenCell> SceneGardenCells;
    }
}
