using UnityEngine;
using System.Collections.Generic;
using Game.Core;
using Game.Data;

namespace Game.ParticleEffects
{
    public class ParticleEffectFactory
    {
        private readonly Transform _parent;

        private readonly ParticleEffectFactoryDataSo _data;

        private readonly Dictionary<ParticleEffectType, ParticleSystem> _particleSystemPrefabs = new();

        public ParticleEffectFactory(ParticleEffectFactoryDataSo data, Transform parent)
        {
            _data = data;

            foreach (ParticleEffectDataSo prefab in data.ParticleEffectPrefabs)
            {                
                _particleSystemPrefabs.Add(prefab.ParticleEffectType, prefab.ParticleSystemPrefab);
            }

            _parent = parent;
        }

        public List<ParticleSystem> CreatePool(ParticleEffectType particleEffectType)
        {
            List<ParticleSystem> pool = new List<ParticleSystem>();

            for (int i = 0; i < _data.PoolSize; i++)
            {
                ParticleSystem particleSystem = Object.Instantiate(_particleSystemPrefabs[particleEffectType], _parent);
                particleSystem.Stop();
                
                pool.Add(particleSystem);
            }

            return pool;
        }
    }
}


