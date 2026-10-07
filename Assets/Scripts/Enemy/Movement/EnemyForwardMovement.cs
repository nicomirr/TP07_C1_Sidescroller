using UnityEngine;

namespace Game.Enemy
{
    public class EnemyForwardMovement : EnemyMovement
    {       
        public EnemyForwardMovement(float movementSpeed, Rigidbody2D rb) : base(movementSpeed, rb)
        {
        }

        public override void Move()
        {
            _rb.linearVelocity = new Vector2(-_movementSpeed, _rb.linearVelocity.y);
        }
    }
}
