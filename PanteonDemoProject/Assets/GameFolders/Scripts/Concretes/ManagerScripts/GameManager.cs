using PanteonDemoProject.Abstracts.GameStates;
using PanteonDemoProject.Concretes.ObstacleSettings;
using UnityEngine;
using System;

namespace PanteonDemoProject.Concretes.Manager
{
    public class GameManager : MonoBehaviour
    {
        // Game data list that will take GameData Scriptable Object.
        [SerializeField] private RotatingObstacle _rotatingObstacleSettings;

        #region Subject Events

        // The actions that will be triggered when player wins or loses the games.
        public event Action OnRunningGameWon;
        public event Action OnRunningGameLost;
        public event Action OnPaintingGameWon;

        // The actions that will be triggered when player ready to running or when player has get started or over the running game.
        public event Action OnReadyToRun;
        public event Action OnStartToRun;
        public event Action OnRunningGameOver;

        // The actions that will be triggered when player ready to painting or when player has get started or over the painting game.
        public event Action OnReadyToPaint;
        public event Action OnStartToPaint;
        public event Action OnPaintingGameOver;
        
        #endregion

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


        // Creating subject methods
        public void InitializeOnRunningGameWon()
        {
            GameState = GameStates.InRunningOver;
            OnRunningGameWon?.Invoke();
        }

        public void InitializeOnRunningGameLost()
        {
            GameState = GameStates.InRunningOver;
            OnRunningGameLost?.Invoke();
        }

        public void InitializeOnPaintingGameWon()
        {
            GameState = GameStates.InPaintingOver;
            OnPaintingGameWon?.Invoke();
        }

        public void InitializeOnReadyToRun()
        {
            GameState = GameStates.InReadyToRun;
            OnReadyToRun?.Invoke();
        }

        public void InitializeOnStartToRun()
        {
            GameState = GameStates.InRunning;
            OnStartToRun?.Invoke();
        }

        public void InitializeOnRunningGameOver()
        {
            GameState = GameStates.InRunningOver;
            OnRunningGameOver?.Invoke();
        }

        public void InitializeOnReadyToPaint()
        {
            GameState = GameStates.InReadyToPaint;
            OnReadyToPaint?.Invoke();
        }

        public void InitializeOnStartToPaint()
        {
            GameState = GameStates.InPainting;
            OnStartToPaint?.Invoke();
        }

        public void InitializeOnPaintingGameOver()
        {
            GameState = GameStates.InPaintingOver;
            OnPaintingGameOver?.Invoke();
        }
    }
}