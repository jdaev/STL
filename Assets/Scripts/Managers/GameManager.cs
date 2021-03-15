using UnityEngine;

namespace Managers
{
    public class GameManager
    {
        private Blaster _blaster;
        private Player _player;
        
        
        #region Singleton
        private GameManager() { }
        private static GameManager _instance;
        public static GameManager Instance => _instance ??= new GameManager();

        #endregion

        public void Initialize(Blaster blaster, Player _player)
        {
            this._blaster = blaster;
            this._player = _player;
            _blaster.Initialize();
        }

        public void Refresh()
        {
            _blaster.Refresh();
        }
    }
}
