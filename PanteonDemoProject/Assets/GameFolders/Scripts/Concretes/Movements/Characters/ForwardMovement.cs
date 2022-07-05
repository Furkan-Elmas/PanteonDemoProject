using UnityEngine;

namespace PanteonDemoProject.Concretes.Movements
{
    public class ForwardMovement
    {
        Rigidbody _playerRigidbody;

        // Creating a constructor method that will be taken Rigidbody component from player as a parameter.
        public ForwardMovement(Rigidbody playerRigidbody)
        {
            _playerRigidbody = playerRigidbody;
        }

        // A mover method that will be run at Player Controller script.
        public void MoveForward(float forwardSpeed)
        {
            Vector3 direction = Vector3.forward * forwardSpeed * Time.fixedDeltaTime;
            _playerRigidbody.transform.Translate(direction,Space.World);
        }
    }
}