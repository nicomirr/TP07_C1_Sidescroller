using UnityEngine;
using System.Collections.Generic;
using Game.AnimationSystem;
using Game.Audio;
using Game.Core;
using Game.Data;
using Game.Marker;
using Game.ParticleEffects;

namespace Game.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerConfigSo _data;

        private PlayerInputs _playerInputs;
        private AnimationHandler _animationHandler;
        private PlayerFacing _playerFacing;
        private PlayerMovement _playerMovement;
        private PlayerJump _playerJump;
        private PlayerGroundCheck _playerGroundCheck;
        private PlayerGravity _playerGravity;

        private void Awake()
        {
            _playerInputs = new PlayerInputs();

            AnimationLibrary animationLibrary = new AnimationLibrary(_data.AnimationsConfig, this.gameObject);
            _animationHandler = new AnimationHandler(GetComponentInChildren<Animator>(), animationLibrary);

            _playerFacing = new PlayerFacing(this.transform);

            Rigidbody2D rb = GetComponent<Rigidbody2D>();

            _playerMovement = new PlayerMovement(rb, _data);

            AudioPlayer audioPlayer = new AudioPlayer(_data.AudioConfigData, GetComponentInChildren<AudioSource>());

            List<ParticleEffect> effects = new(GetComponentsInChildren<ParticleEffect>());
            ParticleEffectsPlayer particleEffectsPlayer = new ParticleEffectsPlayer(effects);

            _playerJump = new PlayerJump(rb, _data, particleEffectsPlayer, audioPlayer);

            Transform groundCheck = GetComponentInChildren<GroundCheckMarker>().transform;
            _playerGroundCheck = new PlayerGroundCheck(groundCheck, _data);

            _playerGravity = new PlayerGravity(rb, _data);
        }

        private void OnEnable()
        {            
            _playerGroundCheck.OnJustLanded += HandleLand;
        }

        private void FixedUpdate()
        {
            HandleMovement();     
        }

        private void Update()
        {
            _playerFacing.FlipPlayer(_playerInputs.Direction);
            _animationHandler.SetFloat(AnimationType.PlayerDirection, _playerFacing.IsFacingRight ? 1f : -1f);
            
            HandleJump();
        }

        private void OnDisable()
        {
            _playerGroundCheck.OnJustLanded -= HandleLand;

            _playerInputs.Deinitialize();
        }

        private void HandleJump()
        {
            _playerGroundCheck.UpdateGroundedState();
                        
            if (_playerInputs.JumpReleased && !_playerGroundCheck.IsGrounded)
                _playerJump.CutJump();

            if (_playerInputs.JumpPressed && _playerGroundCheck.IsGrounded)
            {
                _playerJump.Jump();
                _animationHandler.SetBool(AnimationType.PlayerIsJumping, true);        
            }

            _playerGravity.UpdateGravity();
        }

        private void HandleLand()
        {
            _animationHandler.SetBool(AnimationType.PlayerIsJumping, false);            
        }

        private void HandleMovement()
        {
            _playerMovement.Move(_playerInputs.Direction);

            _animationHandler.SetBool(AnimationType.PlayerIsMoving, _playerInputs.Direction != 0);
        }        
    }
}


