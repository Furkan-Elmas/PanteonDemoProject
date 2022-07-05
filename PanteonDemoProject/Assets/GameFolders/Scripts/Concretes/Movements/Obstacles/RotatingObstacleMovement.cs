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
            _rotatorRigidbody = GetComponent<Rigidbody>();
        }

        void Start()
        {
            _rotatorRigidbody.centerOfMass = transform.localPosition;
        }

        void FixedUpdate()
        {
            _rotatorRigidbody.AddRelativeTorque(transform.up * _movementSettings.RotationSpeed, ForceMode.VelocityChange);
        }
    }
}