using Base;
using UnityEngine;

namespace Managers
{
    public class PlayerManager
    {
        public Player Player;
        private Blaster _rightBlaster;
        private Blaster _leftBlaster;

        public int Score () =>GameManager.Instance.EnemyManager.EnemiesKilled*_streak ;

        private int _streak = 1;
        private int _hits = 0;

        private readonly int _hitsToKill = 5;
        private readonly int _killsToStreak = 5;

        private int _streakTime = 10;
        private int _hitTime = 10;


        private float _secondsSinceLastHit = 0;
        private float _secondsSinceLastKill = 0;

        private int _lastHitCount = 0;
        private int _lastKillCount = 0;

        public void Initialize(Player player, Blaster rightBlaster,Blaster leftBlaster)
        {
            Player = player;
            _rightBlaster = rightBlaster;
            _leftBlaster = leftBlaster;

            Player.Initialize();
            _rightBlaster.Initialize();
            _leftBlaster.Initialize();
        }

        public void Refresh()
        {
            Player.Refresh();
            
            _rightBlaster.Refresh();
            _leftBlaster.Refresh();
            
            HitTimer();
            StreakTimer();
            
            UIManager.Instance.UpdateHUD(Score().ToString(),Player.HitCount.ToString());
        }

        private void HitTimer()
        {
            if (_hits >= _hitsToKill)
            {
                Player.Kill();
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
                _streak = _streak * 2;
                return;
            }
            if (_secondsSinceLastKill >= _streakTime)
            {
                _streak = 1;
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