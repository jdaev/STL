﻿using Base;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameFlow : MonoBehaviour
    {
        [Header("Devices")] [SerializeField] private GameObject rightController;
        [SerializeField] private GameObject leftController;

        [Header("Player")] [SerializeField] private Blaster rightBlaster;
        [SerializeField] private Blaster leftBlaster;
        [SerializeField] private Player player;

        [Header("Audio")] [SerializeField] private AudioSource musicSource;

        [Header("UI")] [SerializeField] private GameObject pauseMenu;
        [SerializeField] private GameObject gameOverMenu;
        [SerializeField] private GameObject victoryMenu;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI hitText;

        [Header("Input")] public InputActionReference pauseActionReference;


        private bool _isPaused = false;
        private const string MainMenuScene = "MenuScene";
        private const string GameScene = "GameScene";

        public void Start()
        {
            Time.timeScale = 1;
            
            UIManager.Instance.Initialize(gameOverMenu, pauseMenu, victoryMenu, scoreText, hitText);
            ControllerManager.Instance.Initialize(leftController, rightController, pauseActionReference);

            ControllerManager.Instance.PauseInputAction.action.performed += PauseGame;
            GameManager.Instance.Initialize(rightBlaster, leftBlaster, player, musicSource);
        }


        public void Update()
        {
            if (_isPaused) return;
            GameManager.Instance.Refresh();
            UIManager.Instance.Refresh();
        }

        public void FixedUpdate()
        {
        }

        private void PauseGame(InputAction.CallbackContext callbackContext)
        {
            if (_isPaused)
            {
                UnPause();
            }
            else
            {
                _isPaused = true;
                ControllerManager.Instance.ToggleInteractors(true);

                Time.timeScale = 0;
                musicSource.Pause();
                UIManager.Instance.OnPause();
            }
        }

        public void UnPause()
        {
            _isPaused = false;
            ControllerManager.Instance.ToggleInteractors(false);

            Time.timeScale = 1;
            musicSource.Play();
            UIManager.Instance.OnResume();
        }


        public void ReloadScene()
        {
            
            _isPaused = false;
            ControllerManager.Instance.ToggleInteractors(false);
            ObjectPool.Instance.ClearPool();
            Time.timeScale = 1;
            musicSource.Play();
            UIManager.Instance.OnResume();
            SceneManager.LoadScene(GameScene);
        }


        public void LoadMainMenu()
        {
            Time.timeScale = 1;

            SceneManager.LoadScene(MainMenuScene);
        }
    }
}