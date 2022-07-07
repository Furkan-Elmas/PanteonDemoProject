using PanteonDemoProject.Abstracts.Settings;
using UnityEngine;

namespace PanteonDemoProject.Concretes.Movements
{
    public class RotatingPlatformMovement : MonoBehaviour
    {
        [SerializeField] RotatingPlatformSettings _rotatingPlatformSettings;

        ConstantForce _platformConstantForce;


        void Awake()
        {
            _platformConstantForce = GetComponent<ConstantForce>();
        }

        void Start()
        {
            _platformConstantForce.torque *= _rotatingPlatformSettings.RotationSpeed;
        }
    }
}