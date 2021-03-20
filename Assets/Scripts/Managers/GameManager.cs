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
        
        private readonly EnemySpawnerManager EnemySpawnerManager = new EnemySpawnerManager();
        private readonly LevelManager LevelManager = new LevelManager();
        
        public Level Level => LevelManager.Level;
        public float PlayerProgress => LevelManager.PlayerProgress;

        public float PlayerHeight { get; private set; } = 1.8f;
        
        #region Singleton
        private GameManager() { }
        private static GameManager _instance;
        public static GameManager Instance => _instance ??= new GameManager();

        #endregion

        public void Initialize(Blaster blaster, Player player)
        {
            PlayerManager.Initialize( player,blaster);
            EnemyFactory.Initialize();
            EnemyManager.Initialize();
            EnemySpawnerManager.Initialize();
            StartGame();
            
        }

        public void StartGame()
        {
            LevelManager.LoadFromJson();
            foreach (var spawnPoint in Level.spawnPoints)
            {
                EnemySpawnerManager.AddEnemySpawner(spawnPoint, Level.levelLength, Level.spawnDistanceFromPlayer);
            }
        }

        public void Refresh()
        {
            PlayerManager.Refresh();
            EnemyManager.Refresh();
            EnemySpawnerManager.Refresh();
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene("TestScene");
        }
    }
}
