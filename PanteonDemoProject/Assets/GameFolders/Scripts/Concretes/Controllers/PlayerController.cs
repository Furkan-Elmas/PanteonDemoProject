using UnityEngine;
using PanteonDemoProject.Abstracts.AnimationControl;
using PanteonDemoProject.Abstracts.Inputs;
using PanteonDemoProject.Concretes.Manager.States;
using PanteonDemoProject.Concretes.Manager;
using PanteonDemoProject.Concretes.Player.Movements;

namespace PanteonDemoProject.Concretes.Player.Controller
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _forwardSpeed;
        [SerializeField] float _swerveSpeed;

        SwerveMovement _swerveMovement;
        Rigidbody _playerRigidbody;
        InputData _inputData;


        void Awake()
        {
            _swerveMovement = new SwerveMovement(this);
            _inputData = new InputData();
        }

        void FixedUpdate()
        {
            if(GameManager.Instance.GameState == GameStates.InRunning)
                _swerveMovement.SwervePlayer(_swerveSpeed, _inputData.DeltaXValue);
        }
    }
}