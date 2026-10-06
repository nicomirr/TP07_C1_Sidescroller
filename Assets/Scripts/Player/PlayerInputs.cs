using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
    public class PlayerInputs
    {
        public bool JumpPressed => _jumpAction.WasPressedThisFrame();
        public bool JumpReleased => _jumpAction.WasReleasedThisFrame();

        public bool ThrowPressed => _throwAction.WasPressedThisFrame();

        public float Direction => _movementAction.ReadValue<Vector2>().x;

        private readonly GameControls _playerControls;

        private InputAction _jumpAction;
        private InputAction _throwAction;
        private InputAction _movementAction;

        public PlayerInputs()
        {
            _playerControls = new GameControls();

            _jumpAction = _playerControls.Player.Jump;
            _throwAction = _playerControls.Player.Throw;
            _movementAction = _playerControls.Player.Movement;

            EnablePlayerInputs();
        }

        public void EnablePlayerInputs()
        {
            _playerControls.Player.Enable();
        }

        public void DisablePlayerInputs()
        {
            _playerControls.Player.Disable();
        }

        public void Deinitialize()
        {
            _playerControls.Player.Disable();           
            _playerControls.Dispose();
        }
    }
}

