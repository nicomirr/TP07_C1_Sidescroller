using UnityEngine;
using Game.Audio;
using Game.Core;
using Game.Data;
using Game.ParticleEffects;

namespace Game.Player
{
    public class PlayerJump
    {
        private readonly JumpDataSo _data;

        private readonly Rigidbody2D _rb;

        private readonly ParticleEffectsPlayer _particleEffectsPlayer;
        private readonly AudioPlayer _audioPlayer;

        private float _coyoteTimer;

        public bool CanJump => _coyoteTimer > 0;

        public PlayerJump(Rigidbody2D rb, PlayerConfigSo data)
        {
            _rb = rb;
            _data = data.JumpData;
        }

        public void UpdateCoyoteTime(bool isGrounded)
        {
            if (isGrounded)
                _coyoteTimer = _data.CoyoteTime;
            else
                _coyoteTimer -= Time.deltaTime;
        }

        public void Jump()
        {
            _coyoteTimer = 0;

            _rb.AddForce(Vector2.up * _data.JumpForce, ForceMode2D.Impulse);
        }

        public void CutJump()
        {
            if (_rb.linearVelocityY <= 0)
                return;

            _rb.linearVelocityY *= _data.JumpCutMultiplier;
        }        
    }
}

