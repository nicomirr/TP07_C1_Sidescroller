using UnityEngine;
using System.Collections.Generic;
using Game.Core;

namespace Game.Throwables
{
    public class ThrowablePool
    {
        private readonly ThrowableFactory _throwableFactory;

        private readonly Dictionary<ThrowableType, List<Throwable>> _throwables = new();

        public ThrowablePool(ThrowableFactory throwableFactory)
        {
            _throwableFactory = throwableFactory;
        }

        public Throwable RequestThrowable(ThrowableType type)
        {
            if(!_throwables.ContainsKey(type))
                _throwables.Add(type, _throwableFactory.CreatePool(type));            

            List<Throwable> currentThrowables = _throwables[type];
                        
            foreach (Throwable throwable in currentThrowables)
            {
                if(!throwable.gameObject.activeSelf)
                    return throwable;
            }

            Debug.LogError("Error. El pool de objetos arrojables deberia tener siempre un objeto disponible.");

            return null;
        }

    }
}

