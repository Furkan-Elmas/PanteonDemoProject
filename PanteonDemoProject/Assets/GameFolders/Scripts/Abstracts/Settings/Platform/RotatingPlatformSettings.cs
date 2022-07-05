using UnityEngine;

namespace PanteonDemoProject.Concretes.ObstacleSettings
{
    [CreateAssetMenu(fileName ="RotatingPlatformSettings",menuName ="Platform Runner/Settings/Rotating Platform")]
    public class RotatingPlatformSettings : ScriptableObject
    {
        [SerializeField] float _rotationSpeed;
    }
}