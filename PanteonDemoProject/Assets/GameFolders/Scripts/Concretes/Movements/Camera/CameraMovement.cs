using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PanteonDemoProject.Concretes.CameraControl
{
    public class CameraMovement
    {
        Camera _runningCamera;

        public CameraMovement(Camera runningCamera)
        {
            _runningCamera = runningCamera;
        }

        public void MoveCamera(Transform target, float verticalOffset, float horizontalOffset, float followSpeed)
        {
            Vector3 targetedPosition = target.position - new Vector3(0, verticalOffset, horizontalOffset);
            _runningCamera.transform.position = Vector3.Lerp(_runningCamera.transform.position, targetedPosition, Time.fixedDeltaTime * followSpeed);
        }
    }
}