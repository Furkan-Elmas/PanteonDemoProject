using UnityEngine;
using UnityEngine.UI;

namespace PanteonDemoProject.Concretes.Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] GameObject _startPanel;
        [SerializeField] GameObject _paintProgress;

        [SerializeField] Text _currentRank;
        [SerializeField] Text _paintProgressText;

        
        void OnEnable()
        {
            GameManager.Instance.OnReadyToRun += HideCurrentRank;
            GameManager.Instance.OnReadyToRun += HidePaintProgress;
            GameManager.Instance.OnReadyToRun += ShowStartPanel;

            GameManager.Instance.OnStartToRun += HideStartPanel;
            GameManager.Instance.OnStartToRun += ShowCurrentRank;

            GameManager.Instance.OnStartToPaint += HideCurrentRank;
            GameManager.Instance.OnStartToPaint += ShowPaintProgress;

            GameManager.Instance.OnPercentageIncrease += UpdatePaintProgress;
            GameManager.Instance.OnRankUpdate += UpdateCurrentRank;
        }

        void ShowStartPanel()
        {
            _startPanel.SetActive(true);
        }

        void HideStartPanel()
        {
            _startPanel.SetActive(false);
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

        void UpdateCurrentRank(int rank)
        {
            _currentRank.text = $"Rank: {rank}/11";
        }

        void UpdatePaintProgress(int percentage)
        {
            _paintProgressText.text = $"{percentage}% Completed";
        }

        public void TapToStartButton()
        {
            GameManager.Instance.InitializeOnStartToRun();
        }

        void OnDisable()
        {
            GameManager.Instance.OnReadyToRun -= HideCurrentRank;
            GameManager.Instance.OnReadyToRun -= HidePaintProgress;
            GameManager.Instance.OnReadyToRun -= ShowStartPanel;

            GameManager.Instance.OnStartToRun -= HideStartPanel;
            GameManager.Instance.OnStartToRun -= ShowCurrentRank;

            GameManager.Instance.OnStartToPaint -= HideCurrentRank;
            GameManager.Instance.OnStartToPaint -= ShowPaintProgress;

            GameManager.Instance.OnPercentageIncrease -= UpdatePaintProgress;
            GameManager.Instance.OnRankUpdate -= UpdateCurrentRank;
        }
    }
}