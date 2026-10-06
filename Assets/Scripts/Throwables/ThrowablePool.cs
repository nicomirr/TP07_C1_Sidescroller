using UnityEngine;
using System.Collections.Generic;
using Game.Core;

namespace Game.Throwables
{
    public class ThrowablePool
    {
        private Dictionary<ThrowableType, List<GameObject>> _throwables;

        public GameObject RequestThrowable(ThrowableType type)
        {
            List<GameObject> currentThrowables = _throwables[type];

            foreach (GameObject throwable in currentThrowables)
            {
                if(!throwable.activeSelf)
                    return throwable;
            }

            Debug.LogError("Error. El pool de objetos arrojables deberia tener siempre un objeto disponible.");

            return null;
        }

    }
}

