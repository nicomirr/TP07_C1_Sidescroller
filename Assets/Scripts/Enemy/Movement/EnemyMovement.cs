using UnityEngine;

namespace Game.Enemy
{
    public abstract class EnemyMovement
    {
        protected readonly float _movementSpeed;
        protected readonly Rigidbody2D _rb;

        public EnemyMovement(float movementSpeed, Rigidbody2D rb)
        {
            _movementSpeed = movementSpeed;
            _rb = rb;
        }

        public abstract void Move();        
    }
}
