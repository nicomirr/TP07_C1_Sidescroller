using UnityEngine;
using System.Collections.Generic;
using Game.Data;
using Game.Core;

namespace Game.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private UIEnemyHealth _UIHealth;

        [SerializeField] private EnemyDataSo _data;

        private EnemyMovement _enemyMovement;
        private EnemyHealth _enemyHealth;

        private void Awake()
        {
            _enemyMovement = EnemyBehaviourFactory.CreateMovement(_data.MovementData.MovementType, _data.MovementData.MovementSpeed, GetComponent<Rigidbody2D>());
            _enemyHealth = new EnemyHealth(_data);
        }

        private void OnEnable()
        {
            _enemyHealth.OnHealthChanged += _UIHealth.UpdateHealth;
        }

        private void FixedUpdate()
        {
            _enemyMovement.Move();
        }

        private void OnDisable()
        {
            _enemyHealth.OnHealthChanged -= _UIHealth.UpdateHealth;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            MonoBehaviour[] components = collision.GetComponents<MonoBehaviour>();

            IDamageProvider damageProvider = null;

            foreach (MonoBehaviour component in components)
            {
                damageProvider = component as IDamageProvider;

                if (damageProvider != null) break;
            }

            if (damageProvider == null) return;

            _enemyHealth.TakeDamage(damageProvider.Damage);            
        }
    }

}

