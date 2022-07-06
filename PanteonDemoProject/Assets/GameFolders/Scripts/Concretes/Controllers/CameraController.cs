using PanteonDemoProject.Abstracts.GameState;
using PanteonDemoProject.Concretes.Managers;
using PanteonDemoProject.Concretes.Movements;
using UnityEngine;

namespace PanteonDemoProject.Concretes.Controllers
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] Transform _paintingWall;
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

        void OnEnable()
        {
            GameManager.Instance.OnStartToPaint += EditCullingMask;
            GameManager.Instance.OnReadyToRun += ResetCameraRotation;
            GameManager.Instance.OnReadyToRun += ResetCullingMask;
        }

        void FixedUpdate()
        {
            if (GameManager.Instance.GameState == GameStates.InRunning || GameManager.Instance.GameState == GameStates.InReadyToRun)
            {
                _cameraMover.MoveCamera(_targetOfCamera.transform, _verticalCameraOffset, _horizontalCameraOffset, _cameraFollowSpeed);
            }

            if (GameManager.Instance.GameState == GameStates.InPainting)
            {
                _cameraMover.MoveCamera(_paintingWall, 0, 30f, _cameraFollowSpeed);
                SetCameraRotation();
            }
        }

        void EditCullingMask()
        {
            _runningCamera.cullingMask = LayerMask.GetMask("UI");
        }

        void ResetCullingMask()
        {
            _runningCamera.cullingMask = LayerMask.GetMask("Statics", "Dynamics", "Characters");
        }

        void SetCameraRotation()
        {
            _cameraMover.SetCameraRotation(_cameraFollowSpeed);
        }

        void ResetCameraRotation()
        {
            _cameraMover.ResetCameraRotation();
        }

        void OnDisable()
        {
            GameManager.Instance.OnStartToPaint -= EditCullingMask;
            GameManager.Instance.OnReadyToRun -= ResetCameraRotation;
            GameManager.Instance.OnReadyToRun -= ResetCullingMask;
        }
    }
}