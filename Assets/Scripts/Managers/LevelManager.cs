using System;
using System.Collections.Generic;
using System.IO;
using Base;
using UnityEngine;
using UnityEngine.Networking;

namespace Managers
{
    public class LevelManager
    {
        public Level Level { get; private set; }

        public float PlayerProgress =>
            (GameManager.Instance.PlayerManager.Player.transform.position.z / Level.levelLength) * 100;

        
        public void LoadLevel()
        {
            BetterStreamingAssets.Initialize();
            string level = GameContext.SelectedLevel.ToLower().Replace(" ", string.Empty);
            string json = BetterStreamingAssets.ReadAllText($"Maps/{level}.json");
            Level = JsonUtility.FromJson<Level>(json);
            foreach (var spawnPoint in Level.spawnPoints)
            {
                GameManager.Instance.EnemySpawnerManager.AddEnemySpawner(spawnPoint, Level.levelLength,
                    Level.spawnDistanceFromPlayer);
            }
        }
    }
}