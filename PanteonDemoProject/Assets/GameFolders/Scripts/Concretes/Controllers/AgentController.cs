using System.Collections;
using PanteonDemoProject.Abstracts.Settings;
using PanteonDemoProject.Abstracts.GameState;
using PanteonDemoProject.Concretes.Managers;
using UnityEngine;
using UnityEngine.AI;

namespace PanteonDemoProject.Concretes.Controllers
{
    public class AgentController : MonoBehaviour
    {
        [SerializeField] CharacterSettings _characterSettings; // Using CharacterSettings scriptable object for speed, finish line etc.

        Animator _agentAnimator;
        Rigidbody _agentRigidbody;
        NavMeshAgent _agent;
        Vector3 _targetDestination;
        Vector3 _startPosition;

        AnimationControl _animationControl;
        CurrentRankController _rankController;


        void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _agentRigidbody = GetComponent<Rigidbody>();
            _agentAnimator = GetComponentInChildren<Animator>();

            _animationControl = new AnimationControl(_agentAnimator);

            _startPosition = transform.position;
        }

        void OnEnable()
        {
            GameManager.Instance.OnRunningGameLost += GameRestart;
            GameManager.Instance.OnStartToRun += StartToRun;
        }

        void Start()
        {
            _targetDestination = Vector3.forward * _characterSettings.FinishLine;
        }

        // If an opponent enter a rotating platform his X position will be frozen
        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("RotatingPlatform"))
            {
                _agentRigidbody.constraints = RigidbodyConstraints.FreezePositionX;
            }
        }

        // Otherwise it will be unfrozen
        void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("RotatingPlatform"))
            {
                StartCoroutine(CollisionExitCoroutine());
            }
        }

        void Update()
        {
            _animationControl.WaitOrRun(GameManager.Instance.GameState, true);

            if (GameManager.Instance.GameState == GameStates.InRunning)
            {
                _agent.SetDestination(_targetDestination);

                // If an opponent, reaches to the finish line before the player, game will be over
                if (Vector3.Distance(_targetDestination, transform.position) < 2)
                    GameManager.Instance.InitializeOnRunningGameLost();

                // If the opponent falls it will start over
                if (transform.position.y < _characterSettings.VerticalOffRoadDistance)
                    AgentDeath();
            }
        }

        void GameRestart()
        {
            StartCoroutine(RepositionOpponent());
        }

        void StartToRun()
        {
            _agent.isStopped = false;
        }

        // Waiting for agents to exit the rotating platform
        IEnumerator CollisionExitCoroutine()
        {
            yield return new WaitForSecondsRealtime(2);
            _agentRigidbody.constraints = RigidbodyConstraints.None;
            _agentRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        }

        public void AgentDeath()
        {
            _animationControl.Die();
            _agentRigidbody.isKinematic = true;
            StartCoroutine(RepositionOpponent());
        }

        public IEnumerator RepositionOpponent()
        {
            _agent.isStopped = true;
            yield return new WaitForSecondsRealtime(2);

            while (transform.position != _startPosition) // This loop for if the agent can't move to start position after game stopped
            {
                transform.position = _startPosition;
                yield return new WaitForEndOfFrame();
            }

            _animationControl.AnimationReset();
            _agentRigidbody.isKinematic = false;

            if (GameManager.Instance.GameState == GameStates.InRunning)
                StartToRun();
        }

        void OnDisable()
        {
            GameManager.Instance.OnRunningGameLost -= GameRestart;
            GameManager.Instance.OnStartToRun -= StartToRun;
        }
    }
}