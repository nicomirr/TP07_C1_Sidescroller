using Game.Data;
using UnityEngine;

namespace Game.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private EnemyDataSo _data;

        private EnemyMovement _enemyMovement;

        private void Awake()
        {
            _enemyMovement = EnemyBehaviourFactory.CreateMovement(_data.MovementData.MovementType, _data.MovementData.MovementSpeed, GetComponent<Rigidbody2D>());
        }

        private void FixedUpdate()
        {
            _enemyMovement.Move();
        }
    }

}

