using UnityEngine;

namespace PanteonDemoProject.Abstracts.Settings
{
    [CreateAssetMenu(fileName = "RotatingPlatformSettings", menuName = "Platform Runner/Settings/Rotating Platform Settings")]
    public class RotatingPlatformSettings : ScriptableObject
    {
        [SerializeField] float _rotationSpeed = 50f;

        public float RotationSpeed => _rotationSpeed;
    }
}