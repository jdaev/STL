using UnityEngine;

namespace Managers
{
    public class GameManager
    {

        public PlayerManager PlayerManager = new PlayerManager();
        public EnemyManager EnemyManager = new EnemyManager();
        public EnemyFactory EnemyFactory = new EnemyFactory();
        
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
    }
}
