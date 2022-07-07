using UnityEngine;
using UnityEngine.UI;

namespace PanteonDemoProject.Concretes.Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] GameObject _startPanel;
        [SerializeField] GameObject _restartPanel;
        [SerializeField] GameObject _paintProgress;
        [SerializeField] GameObject _winPanel;

        [SerializeField] Text _currentRank;
        [SerializeField] Text _paintProgressText;

        [SerializeField] Slider _paintProgressBar;


        void OnEnable()
        {
            GameManager.Instance.OnReadyToRun += HideCurrentRank;
            GameManager.Instance.OnReadyToRun += HidePaintProgress;
            GameManager.Instance.OnReadyToRun += HideRestartPanel;
            GameManager.Instance.OnReadyToRun += HideWinPanel;
            GameManager.Instance.OnReadyToRun += ShowStartPanel;

            GameManager.Instance.OnStartToRun += HideStartPanel;
            GameManager.Instance.OnStartToRun += ShowCurrentRank;

            GameManager.Instance.OnRunningGameLost += ShowRestartPanel;

            GameManager.Instance.OnStartToPaint += HideCurrentRank;
            GameManager.Instance.OnStartToPaint += ShowPaintProgress;

            GameManager.Instance.OnPercentageIncrease += UpdatePaintProgress;
            GameManager.Instance.OnRankUpdate += UpdateCurrentRank;

            GameManager.Instance.OnPaintingGameWon += ShowWinPanel;
        }

        void ShowStartPanel()
        {
            _startPanel.SetActive(true);
        }

        void HideStartPanel()
        {
            _startPanel.SetActive(false);
        }

        void ShowRestartPanel()
        {
            _restartPanel.SetActive(true);
        }

        void HideRestartPanel()
        {
            _restartPanel.SetActive(false);
        }

        void ShowCurrentRank()
        {
            _currentRank.enabled = true;
        }

        void HideCurrentRank()
        {
            _currentRank.enabled = false;
        }

        void ShowPaintProgress()
        {
            _paintProgress.SetActive(true);
            _paintProgressText.enabled = true;
        }

        void HidePaintProgress()
        {
            _paintProgress.SetActive(false);
            _paintProgressText.enabled = false;
        }

        void ShowWinPanel()
        {
            _winPanel.SetActive(true);
        }

        void HideWinPanel()
        {
            _winPanel.SetActive(false);
        }

        void UpdateCurrentRank(int rank)
        {
            _currentRank.text = $"Rank: {rank}/11";
        }

        void UpdatePaintProgress(int percentage)
        {
            _paintProgressText.text = $"{percentage}% Completed";
            _paintProgressBar.value = percentage;
        }

        public void TapToStartButton()
        {
            GameManager.Instance.InitializeOnStartToRun();
        }

        public void TapToRestartButton()
        {
            GameManager.Instance.InitializeOnReadyToRun();
        }

        public void TapToQuitButton()
        {
            Application.Quit();
        }

        void OnDisable()
        {
            GameManager.Instance.OnReadyToRun -= HideCurrentRank;
            GameManager.Instance.OnReadyToRun -= HidePaintProgress;
            GameManager.Instance.OnReadyToRun -= HideRestartPanel;
            GameManager.Instance.OnReadyToRun -= HideWinPanel;
            GameManager.Instance.OnReadyToRun -= ShowStartPanel;

            GameManager.Instance.OnStartToRun -= HideStartPanel;
            GameManager.Instance.OnStartToRun -= ShowCurrentRank;

            GameManager.Instance.OnRunningGameLost -= ShowRestartPanel;

            GameManager.Instance.OnStartToPaint -= HideCurrentRank;
            GameManager.Instance.OnStartToPaint -= ShowPaintProgress;

            GameManager.Instance.OnPercentageIncrease -= UpdatePaintProgress;
            GameManager.Instance.OnRankUpdate -= UpdateCurrentRank;

            GameManager.Instance.OnPaintingGameWon -= ShowWinPanel;
        }
    }
}