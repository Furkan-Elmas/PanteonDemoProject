using System.Collections.Generic;
using System.Collections;
using System.Linq;
using PanteonDemoProject.Abstracts.GameState;
using PanteonDemoProject.Concretes.Managers;
using UnityEngine;

namespace PanteonDemoProject.Concretes.Controllers
{
    public class CurrentRankController : MonoBehaviour
    {
        List<GameObject> _allCharacters;

        Dictionary<string, GameObject> _characters = new Dictionary<string, GameObject>(); // Creating a dictionary list of characters, include their name and GameObject value


        void Awake()
        {
            _allCharacters = GameObject.FindGameObjectsWithTag("Opponent").ToList(); // Find and add all of opponents that is in the game area
            _allCharacters.Add(GameObject.FindWithTag("Player")); // Add player

            foreach (GameObject character in _allCharacters)
            {
                _characters.Add(character.transform.root.name, character);
            }
        }

        void OnEnable()
        {
            GameManager.Instance.OnStartToRun += StartRanking;
        }

        void StartRanking()
        {
            StartCoroutine(UpdateRankCoroutine());
        }

        IEnumerator UpdateRankCoroutine()
        {
            while (GameManager.Instance.GameState == GameStates.InRunning)
            {
                yield return new WaitForSeconds(0.1f);

                foreach (GameObject character in _allCharacters)
                {
                    UpdateRank(character);
                }
            }
        }

        void UpdateRank(GameObject character)
        {
            _characters[character.transform.root.name] = character;
            IOrderedEnumerable<KeyValuePair<string, GameObject>> sortedCharacters = _characters.OrderByDescending(x => x.Value.transform.root.position.z); // Creating a linqed list and sorting it

            int i = 0;
            foreach (KeyValuePair<string, GameObject> item in sortedCharacters) // Search through the list for finding player
            {
                if (item.Value.CompareTag("Player"))
                {
                    GameManager.Instance.InitializeOnRankUpdate(i + 1); // Taking players (index + 1). That is his rank
                }

                i++;
            }
        }

        void OnDisable()
        {
            GameManager.Instance.OnStartToRun -= StartRanking;
        }
    }
}