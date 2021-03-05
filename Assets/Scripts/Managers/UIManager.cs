namespace Managers
{
    public class UIManager
    {
        #region Singleton
        private UIManager() { }
        private static UIManager _instance;
        public static UIManager Instance => _instance ??= new UIManager();

        #endregion

        public void Initialize()
        {
            
        }

        public void Refresh()
        {
            
        }
    }
}