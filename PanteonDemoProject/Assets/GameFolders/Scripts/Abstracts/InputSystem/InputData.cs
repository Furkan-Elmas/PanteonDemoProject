using UnityEngine.InputSystem;
using UnityEngine;

namespace PanteonDemoProject.Abstracts.Inputs
{
    public class InputData
    {
        DefaultActions _inputActions;

        public Vector2 MousePosition { get; private set; }
        public float DeltaXValue { get; private set; }
        public bool IsClicking { get; private set; }

        public InputData()
        {
            _inputActions = new DefaultActions();

            _inputActions.Player.Swerve.performed += SwerveOnPerformed;
            _inputActions.Player.Move.performed += MoveOnPerformed;
            _inputActions.MousePosition.GetMousePosition.performed += GetMousePositionOnPerformed;

            _inputActions.Enable();
        }

        private void SwerveOnPerformed(InputAction.CallbackContext context)
        {
            DeltaXValue = context.ReadValue<float>();
        }

        private void MoveOnPerformed(InputAction.CallbackContext context)
        {
            IsClicking = context.ReadValueAsButton();
        }

        private void GetMousePositionOnPerformed(InputAction.CallbackContext context)
        {
            MousePosition = context.ReadValue<Vector2>();
        }
    }
}