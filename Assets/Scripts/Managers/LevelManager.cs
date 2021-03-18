namespace Managers
{
    public class LevelManager
    {
        private int levelLength = 385;

        public float PlayerProgress =>
            (GameManager.Instance.PlayerManager.Player.transform.position.z / levelLength) * 100;
    }
}