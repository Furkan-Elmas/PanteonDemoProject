using PanteonDemoProject.Concretes.Managers;
using UnityEngine;

namespace PanteonDemoProject.Concretes.Controllers
{
    public class ObstacleHitController : MonoBehaviour
    {
        void OnTriggerEnter(Collider collider)
        {
            if (collider.transform.CompareTag("Player"))
            {
                GameManager.Instance.InitializeOnRunningGameLost();
            }
            if(collider.gameObject.TryGetComponent(out AgentController agentController))
            {
                agentController.AgentDeath();
            }
        }
    }
}