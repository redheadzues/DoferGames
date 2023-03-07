using UnityEngine;

namespace Assets.CodeBase.Plants
{
    [CreateAssetMenu(fileName = "PlantData", menuName ="StaticData/Plant")]
    public class PlantStaticData : ScriptableObject
    {
        [SerializeField] private float _growTime;
        [SerializeField] private GameObject _template;
        [SerializeField] private ParticleSystem _growParticle;
        [SerializeField] private ParticleSystem _collectParticle;
        [SerializeField] private PlantType _plantType;
    }
}
