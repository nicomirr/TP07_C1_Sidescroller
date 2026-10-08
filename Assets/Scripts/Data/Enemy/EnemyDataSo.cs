using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "EnemyDataSo", menuName = "Scriptable Objects/EnemyDataSo")]
    public class EnemyDataSo : ScriptableObject
    {
        [SerializeField] private EnemyMovementDataSo _movementData;
        public EnemyMovementDataSo MovementData => _movementData;

        [SerializeField] private float _maxHealth;
        public float MaxHealth => _maxHealth;
    }

}

