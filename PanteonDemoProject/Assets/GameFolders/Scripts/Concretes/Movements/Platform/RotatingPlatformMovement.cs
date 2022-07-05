using PanteonDemoProject.Abstracts.Settings;
using UnityEngine;

namespace PanteonDemoProject.Concretes.Movements
{
    public class RotatingPlatformMovement : MonoBehaviour
    {
        [SerializeField] RotatingPlatformSettings _rotatingPlatformSettings;

        Rigidbody _platformRigidbody;


        void Awake()
        {
            _platformRigidbody = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            _platformRigidbody.AddTorque(transform.forward * _rotatingPlatformSettings.RotationSpeed, ForceMode.VelocityChange);
        }
    }
}