using UnityEngine;
using System.Collections.Generic;
using Game.Data;
using Game.Core;

namespace Game.Throwables
{
    public class ThrowableFactory
    {
        private readonly ThrowableFactoryDataSo _data;

        private readonly Dictionary<ThrowableType, Throwable> _throwablesPrefabs = new();

        public ThrowableFactory(ThrowableFactoryDataSo data)
        {
            _data = data;

            foreach(ThrowablePrefabDataSo prefab in data.ThrowablePrefabs)
            {
                if(!prefab.ThrowablePrefab.TryGetComponent<Throwable>(out Throwable throwable))
                {
                    Debug.LogError("Error. Los prefabs para el ThrowableFactory deberian todos ser de tipo Throwable.");
                    return;
                }              

                _throwablesPrefabs.Add(prefab.ThrowableType, throwable);
            }
        }

        public List<Throwable> CreatePool(ThrowableType throwableType)
        {
            List<Throwable> pool = new List<Throwable>();

            for (int i = 0; i < _data.PoolSize; i++)
            {
                Throwable throwable = Object.Instantiate(_throwablesPrefabs[throwableType]);
                throwable.gameObject.SetActive(false);

                pool.Add(throwable);
            }

            return pool;
        }
    }

}

