using UnityEngine;
using Game.Core;

namespace Game.ParticleEffects
{
    public readonly struct PlayParticleEffectCommand : ICommand
    {
        public ParticleEffectType Type { get; }
        public Vector2 Position { get; }

        public PlayParticleEffectCommand(ParticleEffectType type, Vector2 position)
        {
            Type = type;
            Position = position;
        }
    }
}
