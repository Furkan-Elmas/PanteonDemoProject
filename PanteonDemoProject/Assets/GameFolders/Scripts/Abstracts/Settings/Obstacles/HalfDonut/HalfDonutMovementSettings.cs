using UnityEngine;

namespace PanteonDemoProject.Abstracts.Settings
{
    [CreateAssetMenu(fileName = "HalfDonutMovementSettings", menuName = "Platform Runner/Settings/Half Donut Settings")]

    public class HalfDonutMovementSettings : ScriptableObject
    {
        [Header("Vector Length")]
        [SerializeField] Vector3 _tensionVectorLength = new Vector3(0.1f, 0, 0);

        [Header("Forces")]
        [Range(0.5f, 2f)][SerializeField] float _maxRandomPushForce = 1;
        [Range(0.1f, 1f)][SerializeField] float _maxRandomStretchForce = 0.2f;

        public Vector3 TensionVectorLength { get => _tensionVectorLength; }
        public float MaxRandomPushForce { get => _maxRandomPushForce; }
        public float MaxRandomStretchForce { get => _maxRandomStretchForce; }
    }
}