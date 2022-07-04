using PanteonDemoProject.Concretes.Manager.States;
using PanteonDemoProject.Concretes.ObstacleSettings;
using UnityEngine;
using System;

namespace PanteonDemoProject.Concretes.Manager
{
    public class GameManager : MonoBehaviour
    {
        // Game data list that will take GameData Scriptable Object.
        [SerializeField] private RotatingObstacle _rotatingObstacleSettings;

        // The actions that will be triggered when player wins or loses the games.
        public event Action OnRunningGameWon;
        public event Action OnRunningGameLost;
        public event Action OnPaintingGameWon;

        // The actions that will be triggered when player ready to running or when player has get started or over the running game.
        public event Action OnReadyToRunningGame;
        public event Action OnStartToRunningGame;
        public event Action OnRunningGameOver;

        // The actions that will be triggered when player ready to painting or when player has get started or over the painting game.
        public event Action OnReadyToPaintingGame;
        public event Action OnStartToPaintingGame;
        public event Action OnPaintingGameOver;

        // Making singleton class.
        public static GameManager Instance { get; private set; }

        public GameStates GameState { get; private set; }


        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                DestroyImmediate(this.gameObject);
            }
        }

        public void InitializeRunningGameWonStage()
        {
            GameState = GameStates.InRunningOver;
            OnRunningGameWon?.Invoke();
        }

        public void InitializeRunningGameLostStage()
        {
            GameState = GameStates.InRunningOver;
            OnRunningGameLost?.Invoke();
        }

        public void InitializePaintingGameWonStage()
        {
            GameState = GameStates.InPaintingOver;
            OnPaintingGameWon?.Invoke();
        }

        public void InitializeReadyToRunStage()
        {
            GameState = GameStates.InReadyToRun;
            OnReadyToRunningGame?.Invoke();
        }

        public void InitializeStartToRunningGameStage()
        {
            GameState = GameStates.InRunning;
            OnStartToRunningGame?.Invoke();
        }

        public void InitializeRunningGameOverStage()
        {
            GameState = GameStates.InRunningOver;
            OnRunningGameOver?.Invoke();
        }

        public void InitializeReadyToPaintingStage()
        {
            GameState = GameStates.InReadyToPaint;
            OnReadyToPaintingGame?.Invoke();
        }

        public void InitializeStartToPaintingGameStage()
        {
            GameState = GameStates.InPainting;
            OnStartToPaintingGame?.Invoke();
        }

        public void InitializePaintingGameOverStage()
        {
            GameState = GameStates.InPaintingOver;
            OnPaintingGameOver?.Invoke();
        }
    }
}