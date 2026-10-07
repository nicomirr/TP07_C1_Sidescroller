using UnityEngine;
using System.Collections.Generic;
using Game.Core;

namespace Game.ParticleEffects
{
    public class ParticleEffectsPool : MonoBehaviour
    {
        [SerializeField] private List<ParticleEffect> _particleEffects;

        private ParticleEffectsPlayer _particleEffectsPlayer;

        private void Awake()
        {
            _particleEffectsPlayer = new ParticleEffectsPlayer(_particleEffects);                        
        }

        private void OnEnable()
        {
            CommandBus.Register<PlayParticleEffectCommand>(HandlePlayParticleEffect);
        }

        private void OnDisable()
        {
            CommandBus.Unregister<PlayParticleEffectCommand>(HandlePlayParticleEffect);
        }

        private void HandlePlayParticleEffect(PlayParticleEffectCommand command)
        {
            _particleEffectsPlayer.PlayEffect(command.Type, command.Position);
        }
    }

}


