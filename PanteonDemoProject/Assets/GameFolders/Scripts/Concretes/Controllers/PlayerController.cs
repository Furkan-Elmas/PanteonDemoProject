using PanteonDemoProject.Abstracts.AnimationControl;
using PanteonDemoProject.Abstracts.Inputs;
using PanteonDemoProject.Abstracts.Settings;
using PanteonDemoProject.Abstracts.GameState;
using PanteonDemoProject.Concretes.Managers;
using PanteonDemoProject.Concretes.Movements;
using UnityEngine;

namespace PanteonDemoProject.Concretes.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] CharacterSettings _characterSettings;

        Animator _playerAnimator;
        Rigidbody _playerRigidbody;

        ForwardMovement _forwardMovement;
        SwerveMovement _swerveMovement;
        AnimationControl _animationControl;
        InputData _inputData;


        void Awake()
        {
            _playerAnimator = GetComponentInChildren<Animator>();
            _playerRigidbody = GetComponent<Rigidbody>();

            _forwardMovement = new ForwardMovement(_playerRigidbody);
            _swerveMovement = new SwerveMovement(_playerRigidbody);
            _animationControl = new AnimationControl();
            _inputData = new InputData();

            GameManager.Instance.InitializeOnStartToRun();
        }

        void OnEnable()
        {
            GameManager.Instance.OnReadyToRun += RepositionPlayer;
        }

        void OnDisable()
        {
            GameManager.Instance.OnReadyToRun -= RepositionPlayer;
        }

        void Update()
        {
            _animationControl.WaitOrRun(GameManager.Instance.GameState, _playerAnimator, _inputData.IsClicking);
            
            if (GameManager.Instance.GameState == GameStates.InRunning)
            {
                if (transform.position.y < _characterSettings.VerticalOffRoadDistance)
                {
                    GameManager.Instance.InitializeOnRunningGameOver();
                }
                if (transform.position.z > _characterSettings.FinishLine)
                {
                    GameManager.Instance.InitializeOnRunningGameWon();
                }
            }
        }

        void FixedUpdate()
        {
            if (GameManager.Instance.GameState == GameStates.InRunning)
            {
                _swerveMovement.MakeSwarveMovement(_characterSettings.SwerveSpeed, _inputData.DeltaXValue);

                if (_inputData.IsClicking)
                {
                    _forwardMovement.MoveForward(_characterSettings.ForwardSpeed);
                }
            }
        }

        void RepositionPlayer()
        {
            transform.position = Vector3.forward * _characterSettings.StartLine;
        }
    }
}