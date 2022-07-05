using UnityEngine;

namespace PanteonDemoProject.Concretes.Movements
{
    public class RotatingPlatformMovement : MonoBehaviour
    {
        [SerializeField] float _rotationSpeed = 50f;

        Rigidbody _platformRigidbody;

        
        void Awake()
        {
            _platformRigidbody = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            _platformRigidbody.AddTorque(transform.forward * _rotationSpeed,ForceMode.VelocityChange);
        }
    }
}