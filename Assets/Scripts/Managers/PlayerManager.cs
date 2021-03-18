using UnityEngine;

namespace Managers
{
    public class PlayerManager
    {
        public Player Player;
        private Blaster _blaster;

        public int Score { get; private set; } = 0;

        private int _streak = 1;
        private int _hits = 0;

        private readonly int _hitsToKill = 5;
        private readonly int _killsToStreak = 5;

        private int _streakTime = 5;
        private int _hitTime = 5;


        private float _secondsSinceLastHit = 0;
        private float _secondsSinceLastKill = 0;

        private int _lastHitCount = 0;
        private int _lastKillCount = 0;

        public void Initialize(Player player, Blaster blaster)
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

            HitTimer();
            StreakTimer();
        }

        private void HitTimer()
        {
            if (_hits >= _hitsToKill)
            {
                Debug.Log("You Died");
                return;
            }

            if (_secondsSinceLastHit >= _hitTime)
            {
                _hits = 0;
            }
            else 
            {   if(Player.HitCount != _lastHitCount)
                {
                    _hits += Player.HitCount - _lastHitCount;
                    _lastHitCount = Player.HitCount;
                    _secondsSinceLastHit = 0;
                }

                _secondsSinceLastHit += Time.deltaTime;
            }
        }
        private void StreakTimer()
        {
            if (_streak >= _killsToStreak)
            {
                Debug.Log("Streak Multiplied" + _streak);
                return;
            }
            if (_secondsSinceLastKill >= _streakTime)
            {
                _streak = 0;
            }
            else 
            {   if(GameManager.Instance.EnemyManager.EnemiesKilled != _lastKillCount)
                {
                    _streak += GameManager.Instance.EnemyManager.EnemiesKilled - _lastKillCount;
                    _lastHitCount = GameManager.Instance.EnemyManager.EnemiesKilled;
                    _secondsSinceLastKill = 0;
                }

                _secondsSinceLastKill += Time.deltaTime;
            }
            
        }
        
    }
}