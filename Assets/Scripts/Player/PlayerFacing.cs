using UnityEngine;

namespace Game.Player
{
    public class PlayerFacing
    {
        private Transform _playerTransform;

        private bool _isFacingRight;
        public bool IsFacingRight => _isFacingRight;

        public PlayerFacing(Transform playerTransform)
        {
            _playerTransform = playerTransform;
        }

        public void FlipPlayer(float direction)
        {
            if (direction == 0) return;

            _isFacingRight = direction > 0;

            _playerTransform.localScale = new Vector3(Mathf.Sign(direction), _playerTransform.localScale.y, 1);
        }
    }
}
