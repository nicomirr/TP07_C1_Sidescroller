using UnityEngine;
using Game.Core;

namespace Game.Player
{
    public class PlayerCollisionHandler
    {
        private readonly IPlayerStateReader _stateReader;
        private readonly PlayerDamageHandler _damageHandler;

        public PlayerCollisionHandler(IPlayerStateReader stateReader, PlayerDamageHandler damageHandler)
        {
            _stateReader = stateReader;
            _damageHandler = damageHandler;
        }

        public void HandleDamageCollision(GameObject enemyObject, IDamageProvider damageProvider, float damageDirection)
        {
            if (_stateReader.CurrentState == PlayerState.Invincible)
            {
                DestroyDamageCollided(enemyObject);
                return;
            }

            _damageHandler.TryDamage(damageProvider.Damage, damageDirection);
        }

        private void DestroyDamageCollided(GameObject enemy)
        {
            //_audioPlayer.PlayAudio(AudioCategory.PuffDestroySFX);
            //_particleEffectsPlayer.PlayEffect(ParticleEffectType.Destroyed);

            enemy.SetActive(false);
        }
    }

}
