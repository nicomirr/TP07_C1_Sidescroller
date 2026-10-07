using UnityEngine;
using System.Collections.Generic;
using Game.AnimationSystem;
using Game.Audio;
using Game.Core;
using Game.Data;
using Game.Marker;
using Game.ParticleEffects;
using Game.Throwables;

namespace Game.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerConfigSo _data;

        private Rigidbody2D _rb;

        private PlayerAnimationEvents _playerAnimationEvents; 

        private PlayerInputs _playerInputs;
        private AnimationHandler _animationHandler;
        private PlayerFacing _playerFacing;
        private PlayerMovement _playerMovement;
        private PlayerJump _playerJump;
        private PlayerGroundCheck _playerGroundCheck;
        private PlayerGravity _playerGravity;
        private PlayerThrow _playerThrow;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();

            _playerAnimationEvents = GetComponentInChildren<PlayerAnimationEvents>();

            _playerInputs = new PlayerInputs();

            AnimationLibrary animationLibrary = new AnimationLibrary(_data.AnimationsConfig, this.gameObject);
            _animationHandler = new AnimationHandler(GetComponentInChildren<Animator>(), animationLibrary);

            _playerFacing = new PlayerFacing(this.transform);

            _playerMovement = new PlayerMovement(_rb, _data);

            AudioPlayer audioPlayer = new AudioPlayer(_data.AudioConfigData, GetComponentInChildren<AudioSource>());
                        
            _playerJump = new PlayerJump(_rb, _data);

            Transform groundCheck = GetComponentInChildren<GroundCheckMarker>().transform;
            _playerGroundCheck = new PlayerGroundCheck(groundCheck, _data);

            _playerGravity = new PlayerGravity(_rb, _data);

            ThrowableFactory throwableFactory = new ThrowableFactory(_data.ThrowablesFactoryData, GetComponentInChildren<ThrowablesPoolMarker>().transform);

            ThrowablePool throwablePool = new ThrowablePool(throwableFactory);

            _playerThrow = new PlayerThrow(throwablePool, GetComponentInChildren<ThrowableOriginMarker>().transform, _data);
        }

        private void OnEnable()
        {            
            _playerAnimationEvents.OnThrowFinished += HandleThrowFinished;

            _playerGroundCheck.OnJustLanded += HandleLand;
        }

        private void FixedUpdate()
        {
            HandleMovement();     
        }

        private void Update()
        {
            HandlePlayerDirection();

            _playerJump.UpdateCoyoteTime(_playerGroundCheck.IsGrounded);
            HandleJump(); 
            
            _playerThrow.UpdateThrowTimer();
            HandleThrow();

            HandleThrowMovement();
        }

        private void OnDisable()
        {
            _playerAnimationEvents.OnThrowFinished -= HandleThrowFinished;

            _playerGroundCheck.OnJustLanded -= HandleLand;

            _playerInputs.Deinitialize();
        }

        private void HandlePlayerDirection()
        {
            _playerFacing.FlipPlayer(_playerInputs.Direction);
            _animationHandler.SetFloat(AnimationType.PlayerDirection, _playerFacing.IsFacingRight ? 1f : -1f);
        }

        private void HandleJump()
        {
            _playerGroundCheck.UpdateGroundedState();
                        
            if (_playerInputs.JumpReleased && !_playerGroundCheck.IsGrounded)
                _playerJump.CutJump();

            if (_playerInputs.JumpPressed && _playerJump.CanJump)
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

        private void HandleThrow()
        {
            if (!_playerInputs.ThrowPressed || !_playerThrow.CanThrow) return;

            _animationHandler.SetBool(AnimationType.PlayerIsThrowing, true);
        }
        private void HandleThrowMovement()
        {
            float throwMovement;

            if (!_playerGroundCheck.IsGrounded)
                throwMovement = (int)ThrowMovement.Jump;
            else if (_playerInputs.Direction != 0)
                throwMovement = (int)ThrowMovement.Run;
            else
                throwMovement = (int)ThrowMovement.Idle; 

            _animationHandler.SetFloat(AnimationType.PlayerThrowMovement, throwMovement);
        }
        private void HandleThrowFinished()
        {
            _playerThrow.Throw(_playerFacing.IsFacingRight ? 1 : -1, _rb.linearVelocity);

            _animationHandler.SetBool(AnimationType.PlayerIsThrowing, false);
        }

        private void HandleMovement()
        {
            _playerMovement.Move(_playerInputs.Direction);

            _animationHandler.SetBool(AnimationType.PlayerIsMoving, _playerInputs.Direction != 0);
        }              

    }
}


