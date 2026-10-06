using UnityEngine;
using Game.Core;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "ThrowablePrefabDataSo", menuName = "Scriptable Objects/ThrowablePrefabDataSo")]
    public class ThrowablePrefabDataSo : ScriptableObject
    {
        [SerializeField] private ThrowableType _throwableType;
        public ThrowableType ThrowableType => _throwableType;

        [SerializeField] private GameObject _throwablePrefab;
        public GameObject ThrowablePrefab => _throwablePrefab;
    }

}

