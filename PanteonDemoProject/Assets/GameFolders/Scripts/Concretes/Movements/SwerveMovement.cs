using PanteonDemoProject.Concretes.Player.Controller;
using UnityEngine;

namespace PanteonDemoProject.Concretes.Player.Movements
{
    public class SwerveMovement
    {
        PlayerController _playerController;
        Rigidbody _playerRigidbody;

        public SwerveMovement(PlayerController playerController)
        {
            _playerController = playerController;
            _playerRigidbody = _playerController.GetComponent<Rigidbody>();
        }

        public void SwervePlayer(float swerveSpeed, float deltaXValue)
        {
            Vector3 force = Vector3.right* swerveSpeed * deltaXValue;
            _playerRigidbody.AddForce(force,ForceMode.Impulse);
        }
    }
}