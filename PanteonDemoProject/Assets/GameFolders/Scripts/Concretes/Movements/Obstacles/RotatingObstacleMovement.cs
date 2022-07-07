using PanteonDemoProject.Abstracts.Settings;
using UnityEngine;

namespace PanteonDemoProject.Concretes.Movements
{
    public class RotatingObstacleMovement : MonoBehaviour
    {
        [SerializeField] RotatingObstacleMovementSettings _movementSettings;

        ConstantForce _rotatorConstantForce;

        void Awake()
        {
            _rotatorConstantForce = GetComponent<ConstantForce>();
        }

        void Start()
        {
            _rotatorConstantForce.torque *= _movementSettings.RotationSpeed;
        }
    }
}