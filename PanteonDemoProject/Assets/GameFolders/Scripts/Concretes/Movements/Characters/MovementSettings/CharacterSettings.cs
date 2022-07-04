using UnityEngine;

namespace PanteonDemoProject.Abstracts.CharacterSettings
{
    [CreateAssetMenu(fileName ="CharacterSettings",menuName ="Platform Runner/Characters/Character Settings")]
    public class CharacterSettings : ScriptableObject
    {
        [SerializeField] float _forwardSpeed = 5f;
        [SerializeField] float _swerveSpeed = 1f;

        public float ForwardSpeed => _forwardSpeed;
        public float SwerveSpeed => _swerveSpeed;
    }
}