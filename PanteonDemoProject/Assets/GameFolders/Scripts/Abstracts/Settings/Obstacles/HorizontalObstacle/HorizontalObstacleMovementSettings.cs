using UnityEngine;

namespace PanteonDemoProject.Abstracts.Settings
{
    [CreateAssetMenu(fileName = "HorizontalObstacleMovementSettings", menuName = "Platform Runner/Settings/Horizontal Obstacle Settings")]
    public class HorizontalObstacleMovementSettings : ScriptableObject
    {
        [Header("Vector Length")]
        [SerializeField] Vector3 _vectorLength = new Vector3(12f, 0, 0);

        [Header("Speed")]
        [SerializeField] float _movementSpeed = 5f;

        public Vector3 VectorLength => _vectorLength;
        public float MovementSpeed => _movementSpeed;
    }
}