using UnityEngine;
using System.Collections.Generic;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "ParticleEffectFactoryDataSo", menuName = "Scriptable Objects/ParticleEffectFactoryDataSo")]
    public class ParticleEffectFactoryDataSo : ScriptableObject
    {
        [SerializeField] private List<ParticleEffectDataSo> _particleEffectPrefabs;
        public List<ParticleEffectDataSo> ParticleEffectPrefabs => _particleEffectPrefabs;
    }

}

