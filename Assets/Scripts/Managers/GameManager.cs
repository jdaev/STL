using UnityEngine;

namespace Managers
{
    public class GameManager
    {
        private Blaster _blaster;
        
        
        #region Singleton
        private GameManager() { }
        private static GameManager _instance;
        public static GameManager Instance => _instance ??= new GameManager();

        #endregion

        public void Initialize(Blaster blaster)
        {
            this._blaster = blaster;
            _blaster.Initialize();
        }

        public void Refresh()
        {
            _blaster.Refresh();
        }
    }
}
