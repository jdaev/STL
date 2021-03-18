using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameManager
    {

        public readonly PlayerManager PlayerManager = new PlayerManager();
        public readonly EnemyManager EnemyManager = new EnemyManager();
        public readonly EnemyFactory EnemyFactory = new EnemyFactory();
        public readonly LevelManager LevelManager = new LevelManager();
        
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
        }

        public void Refresh()
        {
            PlayerManager.Refresh();
            EnemyManager.Refresh();
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene("TestScene");
        }
    }
}
