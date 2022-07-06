using PanteonDemoProject.Abstracts.Settings;
using UnityEngine;

namespace PanteonDemoProject.Concretes.Movements
{
    public class RotatingObstacleMovement : MonoBehaviour
    {
        [SerializeField] RotatingObstacleMovementSettings _movementSettings;

        Rigidbody _rotatorRigidbody;

        void Awake()
        {
            _rotatorRigidbody = GetComponentInChildren<Rigidbody>();
        }

        void Start()
        {
            _rotatorRigidbody.centerOfMass = _rotatorRigidbody.transform.localPosition;
        }

        void FixedUpdate()
        {
            _rotatorRigidbody.AddRelativeTorque(transform.up * _movementSettings.RotationSpeed, ForceMode.VelocityChange);
        }
    }
}