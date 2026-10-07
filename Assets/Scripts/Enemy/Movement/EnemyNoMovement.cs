using UnityEngine;

namespace Game.Enemy
{
    public class EnemyNoMovement : EnemyMovement
    {
        public EnemyNoMovement(float movementSpeed, Rigidbody2D rb) : base(movementSpeed, rb) {}
        public override void Move() {}
    }
}


