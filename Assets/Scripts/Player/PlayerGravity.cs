using UnityEngine;
using Game.Data;

namespace Game.Player
{
    public class PlayerGravity
    {
        private readonly Rigidbody2D _rb;

        private readonly float _risingGravity;
        private readonly float _fallingGravity;
        private readonly float _apexGravity;

        private readonly float _apexVelocityTreshold;

        public PlayerGravity(Rigidbody2D rb, PlayerConfigSo data)
        {
            _rb = rb;

            _risingGravity = data.GravityData.RisingGravity;
            _fallingGravity = data.GravityData.FallingGravity;
            _apexGravity = data.GravityData.ApexGravity;

            _apexVelocityTreshold = data.GravityData.ApexVelocityThreshold;
        }

        public void UpdateGravity()
        {
            if (_rb.linearVelocityY > _apexVelocityTreshold)
                _rb.gravityScale = _risingGravity;

            else if (_rb.linearVelocityY >= -_apexVelocityTreshold)
                _rb.gravityScale = _apexGravity;

            else
                _rb.gravityScale = _fallingGravity;            
        }
    }

}
