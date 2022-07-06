using PanteonDemoProject.Concretes.Managers;
using UnityEngine;

namespace PanteonDemoProject.Concretes.Controllers
{
    public class ObstacleHitController : MonoBehaviour
    {
        void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.CompareTag("Player"))
            {
                GameManager.Instance.InitializeOnRunningGameLost();
            }
        }
    }
}