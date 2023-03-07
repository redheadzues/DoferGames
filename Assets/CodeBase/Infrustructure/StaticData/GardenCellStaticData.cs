using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.Infrustructure.StaticData
{
    [CreateAssetMenu(fileName = "GardenCellData", menuName = "StaticData/GardenCellsTemplates")]
    public class GardenCellStaticData : ScriptableObject
    {
        [SerializeField] public List<GardenCellData> GardenCellsData;
    }
}
