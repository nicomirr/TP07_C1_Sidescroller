using UnityEngine;
using Game.Core;
using Game.Data;
using Game.Throwables;
using System;


namespace Game.Player
{
    public class PlayerThrow
    {
        private readonly ThrowablePool _throwablePool;

        private readonly Transform _throwOrigin;
        private readonly float _throwCooldown;

        private ThrowableType _currentThrowable;

        private bool _canThrow;
        public bool CanThrow => _canThrow;
        
        private float _throwTimer;


        public PlayerThrow(ThrowablePool throwablePool, Transform throwOrigin, PlayerConfigSo _data) 
        {
            _throwablePool = throwablePool;
            _throwOrigin = throwOrigin;
            _currentThrowable = _data.InitialThrowableType;
            _throwCooldown = _data.ThrowCooldown;

            _canThrow = true;
        }

        public void UpdateThrowTimer()
        {
            if (_canThrow) return;

            _throwTimer += Time.deltaTime;

            if( _throwTimer >= _throwCooldown)
            {
                _throwTimer = 0;
                _canThrow = true;
            }
        }

        public void Throw(float direction, Vector2 throwerVelocity)
        {            
            Throwable throwable = _throwablePool.RequestThrowable(_currentThrowable);

            if (throwable == null)
            {
                Debug.LogError("Error. El pool de objetos arrojables retorno null. Revisar problema en pool.");
                return;
            }
                        
            throwable.gameObject.SetActive(true);

            throwable.Throw(_throwOrigin.position, direction, throwerVelocity);

            _canThrow = false;
        }

    }
}

