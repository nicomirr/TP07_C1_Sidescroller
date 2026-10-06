using UnityEngine;
using System.Collections.Generic;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "ThrowableFactoryDataSo", menuName = "Scriptable Objects/ThrowableFactoryDataSo")]
    public class ThrowableFactoryDataSo : ScriptableObject
    {
        [SerializeField] private List<ThrowablePrefabDataSo> _throwablePrefabs; 
        public List<ThrowablePrefabDataSo> ThrowablePrefabs => _throwablePrefabs;
    }

}

