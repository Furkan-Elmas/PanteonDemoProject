using UnityEngine;

namespace PanteonDemoProject.Abstracts.Settings
{
    [CreateAssetMenu(fileName = "RotatingObstacleMovementSettings", menuName = "Platform Runner/Settings/Rotating Obstacle Settings")]
    public class RotatingObstacleMovementSettings : ScriptableObject
    {
        [SerializeField] float _rotationSpeed = 5f;

        public float RotationSpeed => _rotationSpeed;
    }
}