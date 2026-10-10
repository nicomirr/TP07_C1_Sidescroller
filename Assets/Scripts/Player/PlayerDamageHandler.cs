using UnityEngine;
using System.Collections;
using Game.Audio;
using Game.Core;
using Game.Data;
using Game.Common;

namespace Game.Player
{
    public class PlayerDamageHandler
    {
        private readonly Health _playerHealth;
        //private readonly PlayerDeath _playerDeath;
        private readonly PlayerKnockback _knockback;
        private readonly PlayerSpriteFlicker _spriteFlicker;

        private readonly AudioPlayer _audioPlayer;

        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IPlayerStateChanger _stateChanger;

        private readonly PlayerConfigSo _data;
        private readonly GameObject _player;


        public PlayerDamageHandler(PlayerConfigSo data, Health playerHealth, PlayerKnockback knockback, PlayerSpriteFlicker spriteFlicker, AudioPlayer audioPlayer,
               ICoroutineRunner coroutineRunner, IPlayerStateChanger stateChanger, GameObject player)
        {
            _data = data;

            _playerHealth = playerHealth;
            _knockback = knockback;
            //_playerDeath = playerDeath;
            _spriteFlicker = spriteFlicker;

            _audioPlayer = audioPlayer;

            _coroutineRunner = coroutineRunner;
            _stateChanger = stateChanger;

            _player = player;
        }

        public void TryDamage(float damage, float damageDirection)
        {            
            if (!_stateChanger.TryChangeState(PlayerState.Damaged)) return;

            _knockback.ApplyKnockback(damageDirection);
            _playerHealth.TakeDamage(damage);            

            if (_playerHealth.CurrentHealth <= 0)
            {
                HandleDeath();
                return;
            }

            //_audioPlayer.PlayAudio(AudioCategory.DamageSFX);

            _coroutineRunner.RunCoroutine(DamageRoutine());
        }

        private IEnumerator DamageRoutine()
        {
            yield return _spriteFlicker.FlickerRoutine(_data.DamageFlickerData.Time, _data.DamageFlickerData.TotalBlinks,
                _data.DamageFlickerData.FlickerColor);

            if (!_stateChanger.TryChangeState(PlayerState.Normal))            
                Debug.LogError("ERROR. Deberia poder salir a normal siempre al terminar de recuperarse del daño");            
        }

        private void HandleDeath()
        {
            //PlayerEvents.RaisePlayerDeath();

            //_playerDeath.SpawnSkull();

            _player.SetActive(false);
        }
    }

}
