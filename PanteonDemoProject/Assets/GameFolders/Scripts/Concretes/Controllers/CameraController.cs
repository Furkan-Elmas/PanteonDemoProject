using PanteonDemoProject.Abstracts.GameStates;
using PanteonDemoProject.Concretes.Manager;
using PanteonDemoProject.Concretes.Player.Controller;
using UnityEngine;

namespace PanteonDemoProject.Concretes.CameraControl
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] float _verticalCameraOffset = -10f;
        [SerializeField] float _horizontalCameraOffset = 14f;
        [SerializeField] float _cameraFollowSpeed = 5f;

        Camera _runningCamera;
        CameraMovement _cameraMover;
        GameObject _targetOfCamera;


        void Awake()
        {
            _runningCamera = GetComponent<Camera>();
            _cameraMover = new CameraMovement(_runningCamera);
            _targetOfCamera = GameObject.FindWithTag("Player");
        }

        void FixedUpdate()
        {
            if (GameManager.Instance.GameState == GameStates.InRunning)
            {
                _cameraMover.MoveCamera(_targetOfCamera.transform, _verticalCameraOffset, _horizontalCameraOffset, _cameraFollowSpeed);
            }
        }
    }
}