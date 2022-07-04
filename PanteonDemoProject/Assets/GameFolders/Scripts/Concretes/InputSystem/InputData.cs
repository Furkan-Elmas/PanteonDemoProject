using UnityEngine.InputSystem;

namespace PanteonDemoProject.Abstracts.Inputs
{
    public class InputData 
    {
        DefaultActions _inputActions;

        public float DeltaXValue { get; private set; }
        public bool IsClicking { get; private set; }

        public InputData()
        {
            _inputActions = new DefaultActions();

            _inputActions.Player.Swerve.performed += SwerveOnPerformed;
            _inputActions.Player.Move.performed += MoveOnPerformed;

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
    }
}