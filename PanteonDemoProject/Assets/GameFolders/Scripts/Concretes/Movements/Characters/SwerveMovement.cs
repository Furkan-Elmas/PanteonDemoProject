using UnityEngine;

namespace PanteonDemoProject.Concretes.Player.Movements
{
    public class SwerveMovement
    {
        Rigidbody _playerRigidbody;

        // Creating a constructor method that will be taken Rigidbody component from player as a parameter.
        public SwerveMovement(Rigidbody playerRigidbody)
        {
            _playerRigidbody = playerRigidbody;
        }

        // A mover method that will be run at Player Controller script.
        public void MakeSwarveMovement(float swerveSpeed, float deltaXValue)
        {
            Vector3 force = Vector3.right* swerveSpeed * deltaXValue;
            _playerRigidbody.AddForce(force,ForceMode.Impulse);
        }
    }
}