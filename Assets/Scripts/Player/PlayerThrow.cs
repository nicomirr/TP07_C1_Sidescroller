using UnityEngine;
using Game.Core;
using Game.Data;
using Game.Throwables;


namespace Game.Player
{
    public class PlayerThrow
    {
        private readonly ThrowablePool _throwablePool;

        private readonly Transform _throwOrigin;
        private readonly float _throwCooldown;

        private ThrowableType _currentThrowable;

        public PlayerThrow(ThrowablePool throwablePool, Transform throwOrigin, PlayerConfigSo _data) 
        {
            _throwablePool = throwablePool;
            _throwOrigin = throwOrigin;
            _currentThrowable = _data.InitialThrowableType;
        }

        public void Throw(float direction)
        {
            Throwable throwable = _throwablePool.RequestThrowable(_currentThrowable);

            if (throwable == null)
            {
                Debug.LogError("Error. El pool de objetos arrojables retorno null. Revisar problema en pool.");
                return;
            }
                        
            throwable.gameObject.SetActive(true);

            throwable.Throw(_throwOrigin.position, direction);
        }

    }
}

