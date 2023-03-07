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

        public float GrowTime => _growTime;
        public GameObject Template => _template;
        public ParticleSystem GrowParticle => _growParticle;
        public ParticleSystem CollectParticle => _collectParticle;
        public PlantType PlantType => _plantType;
        
    }
}
