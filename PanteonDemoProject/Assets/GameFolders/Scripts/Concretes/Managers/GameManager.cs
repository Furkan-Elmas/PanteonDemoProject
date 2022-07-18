using PanteonDemoProject.Abstracts.GameState;
using UnityEngine;
using System;

namespace PanteonDemoProject.Concretes.Managers
{
    public class GameManager : MonoBehaviour
    {
        #region Subject Event Actions

        public event Action OnReadyToRun;
        public event Action OnStartToRun;
        public event Action<int> OnRankUpdate;
        public event Action OnRunningGameLost;
        public event Action OnRunningGameWon;

        public event Action OnStartToPaint;
        public event Action<int> OnPercentageIncrease;
        public event Action OnPaintingGameWon;

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

        void Start()
        {
            InitializeOnReadyToRun();
        }

        // Creating observers' method
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

        public void InitializeOnRankUpdate(int rank)
        {
            OnRankUpdate?.Invoke(rank);
        }

        public void InitializeOnRunningGameLost()
        {
            GameState = GameStates.InRunningOver;
            OnRunningGameLost?.Invoke();
        }

        public void InitializeOnRunningGameWon()
        {
            GameState = GameStates.InRunningOver;
            OnRunningGameWon?.Invoke();
        }

        public void InitializeOnStartToPaint()
        {
            GameState = GameStates.InPainting;
            OnStartToPaint?.Invoke();
        }

        public void InitializeOnPercentageIncrease(int percentage)
        {
            OnPercentageIncrease?.Invoke(percentage);
        }

        public void InitializeOnPaintingGameWon()
        {
            GameState = GameStates.InPaintingOver;
            OnPaintingGameWon?.Invoke();
        }
    }
}