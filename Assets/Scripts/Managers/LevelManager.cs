using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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


        public AudioClip Music;

        private readonly List<UnityWebRequest> _runningWebRequests = new List<UnityWebRequest>();

        public void LoadLevel()
        {
            string json = File.ReadAllText(Application.streamingAssetsPath + "/Maps/map.json");
            Level = JsonUtility.FromJson<Level>(json);

            foreach (var spawnPoint in Level.spawnPoints)
            {
                GameManager.Instance.EnemySpawnerManager.AddEnemySpawner(spawnPoint, Level.levelLength,
                    Level.spawnDistanceFromPlayer);
            }
        }
    }
}