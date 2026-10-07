using UnityEngine;
using System.Collections.Generic;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "ParticleEffectFactoryDataSo", menuName = "Scriptable Objects/ParticleEffectFactoryDataSo")]
    public class ParticleEffectFactoryDataSo : ScriptableObject
    {
        [SerializeField] private int _poolSize;
        public int PoolSize => _poolSize;

        [SerializeField] private List<ParticleEffectDataSo> _particleEffectPrefabs;
        public List<ParticleEffectDataSo> ParticleEffectPrefabs => _particleEffectPrefabs;
    }

}

