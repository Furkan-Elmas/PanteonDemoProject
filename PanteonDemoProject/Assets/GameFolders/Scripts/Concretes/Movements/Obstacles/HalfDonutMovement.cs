using PanteonDemoProject.Abstracts.Settings;
using System.Collections;
using UnityEngine;

namespace PanteonDemoProject.Concretes.Movements
{
    public class HalfDonutMovement : MonoBehaviour
    {
        [SerializeField] HalfDonutMovementSettings _halfDonutMovementSettings;


        void Start()
        {
            StartCoroutine(StrechAndPush());
        }

        IEnumerator StrechAndPush()
        {
            // Generate random force
            float randomPushForce = Random.Range(0.5f, _halfDonutMovementSettings.MaxRandomPushForce);

            // Push
            while (transform.localPosition != -_halfDonutMovementSettings.TensionVectorLength)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, -_halfDonutMovementSettings.TensionVectorLength,
                randomPushForce * Time.deltaTime);

                yield return new WaitForEndOfFrame();
            }

            // Generate random force
            float randomStrechForce = Random.Range(0.1f, _halfDonutMovementSettings.MaxRandomStretchForce);

            // Strech
            while (transform.localPosition != _halfDonutMovementSettings.TensionVectorLength)
            {

                transform.localPosition = Vector3.MoveTowards(transform.localPosition, _halfDonutMovementSettings.TensionVectorLength,
                randomStrechForce * Time.deltaTime);

                yield return new WaitForEndOfFrame();
            }

            StartCoroutine(StrechAndPush());
        }
    }
}