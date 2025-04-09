using System;
using UnityEngine;

namespace AltaHyperCasual.Code.UI
{
    public class UIController : MonoBehaviour
    {
        public event Action OnPause;
        public event Action OnContinue;
        public event Action OnRestart;

        [SerializeField] private GameObject _statePanel;
        [SerializeField] private GameObject _pausePanel;
        [SerializeField] private GameObject _pauseButton;
        [SerializeField] private GameObject _winText;
        [SerializeField] private GameObject _loseText;

        public void PauseGame()
        {
            _pausePanel.SetActive(true);
            _pauseButton.SetActive(false);
            OnPause?.Invoke();
        }
        public void ContinueGame()
        {
            _pausePanel.SetActive(false);
            _pauseButton.SetActive(true);
            OnContinue?.Invoke();
        }
        
        public void RestartGame()
        {
            OnRestart?.Invoke();
        }

        public void ShowWinPanel()
        {
            _statePanel.SetActive(true);
            _winText.SetActive(true);
        }

        public void ShowLosePanel()
        {
            _statePanel.SetActive(true);
            _loseText.SetActive(true);
        }
    }
}
