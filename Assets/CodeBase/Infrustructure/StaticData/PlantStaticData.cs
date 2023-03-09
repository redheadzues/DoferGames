using Assets.CodeBase.Plants;
using UnityEngine;

namespace Assets.CodeBase.Infrustructure.StaticData
{
    [CreateAssetMenu(fileName = "PlantData", menuName = "StaticData/Plant")]
    public class PlantStaticData : ScriptableObject
    {
        [SerializeField] private PlantType _plantType;
        [SerializeField, Range(0, 20)] private float _growTime;
        [SerializeField, Range(0, 20)] int _price;
        [SerializeField] private GameObject _template;
        [SerializeField] private PlantBrick _brickTemplate;
        [SerializeField] private ParticleSystem _growParticle;
        [SerializeField] private ParticleSystem _collectParticle;

        public float GrowTime => _growTime;
        public GameObject Template => _template;
        public ParticleSystem GrowParticle => _growParticle;
        public ParticleSystem CollectParticle => _collectParticle;
        public PlantType PlantType => _plantType;

    }
}
