using UnityEngine;
using System.Collections.Generic;
using Game.Core;

namespace Game.ParticleEffects
{
    public class ParticleEffectsPlayer
    {
        //TIENE QUE SER UNA LIOSTA DE PARTICLE SYSTEM PARA EL POOL.
        private Dictionary<ParticleEffectType, ParticleSystem> _particleEffects;

        public ParticleEffectsPlayer(List<ParticleEffect> particleEffects)
        {
            _particleEffects = new Dictionary<ParticleEffectType, ParticleSystem>();

            foreach (ParticleEffect effect in particleEffects)
            {
                _particleEffects.Add(effect.ParticleEffectType, effect.ParticleSystem);
            }
        }

        public void PlayEffect(ParticleEffectType type, Vector2 position)
        {
            ParticleSystem particleSystem = _particleEffects[type];

            particleSystem.transform.position = position;
            particleSystem.Play();
        }

    }        
}


