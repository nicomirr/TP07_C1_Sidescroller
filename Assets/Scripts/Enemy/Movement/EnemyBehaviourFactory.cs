using UnityEngine;
using Game.Core;

namespace Game.Enemy
{
    public static class EnemyBehaviourFactory
    {
        public static EnemyMovement CreateMovement(EnemyMovementType movementType, float movementSpeed, Rigidbody2D rb)
        {
            return movementType switch
            {
                EnemyMovementType.Forward => new EnemyForwardMovement(movementSpeed, rb),
                _ => new EnemyNoMovement(movementSpeed, rb)
            };
        }
    }

}
