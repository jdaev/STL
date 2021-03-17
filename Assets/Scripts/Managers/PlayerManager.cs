namespace Managers
{
    public class PlayerManager
    {
        public Player Player;
        private Blaster _blaster;
        public void Initialize(Player player,Blaster blaster)
        {
            this.Player = player;
            this._blaster = blaster;
            
            Player.Initialize();
            _blaster.Initialize();
        }

        public void Refresh()
        {
            Player.Refresh();
            _blaster.Refresh();
        }
        
    }
}