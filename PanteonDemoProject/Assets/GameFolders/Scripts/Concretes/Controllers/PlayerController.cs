using UnityEngine;
using PanteonDemoProject.Abstracts.AnimationData;
using PanteonDemoProject.Abstracts.Inputs;
using PanteonDemoProject.Abstracts.CharacterSettings;
using PanteonDemoProject.Abstracts.GameStates;
using PanteonDemoProject.Concretes.Manager;
using PanteonDemoProject.Concretes.Player.Movements;

namespace PanteonDemoProject.Concretes.Player.Controller
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] CharacterSettings _characterSettings;

        Animator _playerAnimator;

        SwerveMovement _swerveMovement;
        ForwardMovement _forwardMovement;
        Rigidbody _playerRigidbody;
        InputData _inputData;


        void Awake()
        {
            _playerAnimator = GetComponentInChildren<Animator>();
            _playerRigidbody = GetComponent<Rigidbody>();
            _swerveMovement = new SwerveMovement(_playerRigidbody);
            _forwardMovement = new ForwardMovement(_playerRigidbody);
            _inputData = new InputData();
            GameManager.Instance.InitializeOnStartToRun();
        }

        void FixedUpdate()
        {
            _playerAnimator.SetBool("IsRunning", _inputData.IsClicking);

            if (GameManager.Instance.GameState == GameStates.InRunning)
                _swerveMovement.MakeSwarveMovement(_characterSettings.SwerveSpeed, _inputData.DeltaXValue);
            if (_inputData.IsClicking)
            {
                _forwardMovement.MoveForward(_characterSettings.ForwardSpeed);
            }
        }
    }
}