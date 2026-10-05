using UnityEngine;
using System;
using Game.Data;
using Game.Core;

namespace Game.Player
{
    public abstract class PlayerPowerUp
    {
        protected PowDataSo _data;

        protected ICoroutineRunner _coroutineRunner;
        protected IPlayerStateChanger _playerStateChanger;

        protected SpriteRenderer _spriteRenderer;
        protected PlayerSpriteFlicker _spriteFlicker;

        public event Action OnPowerUpFinalized;
        public abstract bool TryEnablePowerUp();

        protected void RaisePowerUpFinalized()
        {
            OnPowerUpFinalized?.Invoke();
        }
    }

}
