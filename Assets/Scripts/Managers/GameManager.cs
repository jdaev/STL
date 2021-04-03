using Base;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameManager
    {

        public readonly PlayerManager PlayerManager = new PlayerManager();
        
        public readonly EnemyManager EnemyManager = new EnemyManager();
        public readonly EnemyFactory EnemyFactory = new EnemyFactory();
        
        public readonly ProjectileManager ProjectileManager = new ProjectileManager();
        public readonly ProjectileFactory ProjectileFactory = new ProjectileFactory();
        
        public readonly LaserManager LaserManager = new LaserManager();
        public readonly LaserFactory LaserFactory = new LaserFactory();

        public readonly EnemySpawnerManager EnemySpawnerManager = new EnemySpawnerManager();
        
        public readonly AudioManager AudioManager = new AudioManager();
        private readonly LevelManager _levelManager = new LevelManager();

        public AudioSource GameAudioSource;
        public Level Level => _levelManager.Level;
        public float PlayerProgress => _levelManager.PlayerProgress;

        public float PlayerHeight { get; private set; } = 1.8f;
        
        #region Singleton
        private GameManager() { }
        private static GameManager _instance;
        public static GameManager Instance => _instance ??= new GameManager();

        #endregion

        public void Initialize(Blaster rightBlaster,Blaster leftBlaster, Player player,AudioSource audioSource)
        {
            GameAudioSource = audioSource;
            
            
            PlayerManager.Initialize( player,rightBlaster,leftBlaster);
            
            EnemyFactory.Initialize();
            EnemyManager.Initialize();
            
            ProjectileFactory.Initialize();
            ProjectileManager.Initialize();
            
            LaserFactory.Initialize();
            LaserManager.Initialize();
            
            EnemySpawnerManager.Initialize();
            StartGame();
            
        }

        public void StartGame()
        {
            _levelManager.LoadLevel();
            AudioManager.Initialize();
            AudioManager.PlaySoundtrack();
        }

        public void Refresh()
        {
            PlayerManager.Refresh();
            EnemyManager.Refresh();
            ProjectileManager.Refresh();
            LaserManager.Refresh();
            
            EnemySpawnerManager.Refresh();
            
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
