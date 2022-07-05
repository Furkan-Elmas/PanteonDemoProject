using UnityEngine;

namespace PanteonDemoProject.Abstracts.Settings
{
    [CreateAssetMenu(fileName ="CharacterSettings",menuName ="Platform Runner/Characters/Character Settings")]
    public class CharacterSettings : ScriptableObject
    {
        [Header("Speeds")]
        [SerializeField] float _forwardSpeed = 5f;
        [SerializeField] float _swerveSpeed = 1f;

        [Header("Distances")]
        [SerializeField] float _startLine = 0f;
        [SerializeField] float _finishLine = 300f;
        [SerializeField] float _verticalOffRoadDistance = -5f;

        public float ForwardSpeed => _forwardSpeed;
        public float SwerveSpeed => _swerveSpeed;
        public float StartLine => _startLine;
        public float FinishLine => _finishLine;
        public float VerticalOffRoadDistance => _verticalOffRoadDistance;
    }
}