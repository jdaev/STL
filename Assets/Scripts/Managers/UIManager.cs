using TMPro;
using UnityEngine;

namespace Managers
{
    public class UIManager
    {
        #region Singleton
        private UIManager() { }
        private static UIManager _instance;
        public static UIManager Instance => _instance ??= new UIManager();

        #endregion

        private GameObject _gameOverMenu;
        private GameObject _pauseMenu;
        
        private TextMeshProUGUI _scoreText;
        private TextMeshProUGUI _hitText;

        
        public void Initialize(GameObject gameOverMenu,GameObject pauseMenu, TextMeshProUGUI scoreText, TextMeshProUGUI hitText)
        {
            this._gameOverMenu = gameOverMenu;
            this._pauseMenu = pauseMenu;

            _scoreText = scoreText;
            _hitText = hitText;

        }

        public void OnGameOver()
        {
            _pauseMenu.SetActive(false);
            _gameOverMenu.SetActive(true);
        }

        public void UpdateHUD(string score, string hit)
        {
            _scoreText.text = score;
            _hitText.text = hit;
        }

        public void OnPause() => _pauseMenu.SetActive(true);

        public void OnResume() => _pauseMenu.SetActive(false);
        
        public void Refresh()
        {
            
        }
    }
}