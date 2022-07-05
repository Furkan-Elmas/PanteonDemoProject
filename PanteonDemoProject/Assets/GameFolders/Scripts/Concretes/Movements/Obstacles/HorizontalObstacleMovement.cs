using PanteonDemoProject.Abstracts.Settings;
using System.Collections;
using UnityEngine;

namespace PanteonDemoProject.Concretes.Movements
{
    public class HorizontalObstacleMovement : MonoBehaviour
    {
        [SerializeField] HorizontalObstacleMovementSettings _movementSettings;


        void Start()
        {
            StartCoroutine(StrechAndPush());
        }

        IEnumerator StrechAndPush()
        {
            while (transform.localPosition.x != -_movementSettings.VectorLength.x)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(-_movementSettings.VectorLength.x, transform.position.y, transform.position.z),
                _movementSettings.MovementSpeed * Time.deltaTime);

                yield return new WaitForEndOfFrame();
            }

            while (transform.localPosition.x != _movementSettings.VectorLength.x)
            {

                transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(_movementSettings.VectorLength.x, transform.position.y, transform.position.z),
                _movementSettings.MovementSpeed * Time.deltaTime);

                yield return new WaitForEndOfFrame();
            }

            StartCoroutine(StrechAndPush());
        }

    }
}