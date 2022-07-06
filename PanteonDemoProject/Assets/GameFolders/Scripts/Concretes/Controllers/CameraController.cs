using PanteonDemoProject.Abstracts.GameState;
using PanteonDemoProject.Concretes.Managers;
using PanteonDemoProject.Concretes.Movements;
using UnityEngine;

namespace PanteonDemoProject.Concretes.Controllers
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
            if (GameManager.Instance.GameState == GameStates.InRunning || GameManager.Instance.GameState == GameStates.InReadyToRun)
            {
                _cameraMover.MoveCamera(_targetOfCamera.transform, _verticalCameraOffset, _horizontalCameraOffset, _cameraFollowSpeed);
            }
        }
    }
}