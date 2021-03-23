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
        private string musicFile;
        public void LoadFromJson()
        {
            string json = File.ReadAllText(Application.streamingAssetsPath + "/Maps/map.json");
            Level = JsonUtility.FromJson<Level>(json);
             musicFile = "Music/" + Level.soundtrack + ".ogg";
            GameFlow gameFlow = GameObject.Find("MainScripts").GetComponent<GameFlow>();

            gameFlow.StartCoroutine(MusicPlayer());
            foreach (var spawnPoint in Level.spawnPoints)
            {
                GameManager.Instance.EnemySpawnerManager.AddEnemySpawner(spawnPoint, Level.levelLength,
                    Level.spawnDistanceFromPlayer);
            }
        }

        public static string GetFileLocation(string relativePath)
        {
            return "file://" + Path.Combine(Application.streamingAssetsPath, relativePath);
        }

        IEnumerator MusicPlayer()
        {
            Debug.Log(GetFileLocation(musicFile));
            using (UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip(GetFileLocation(musicFile),AudioType.OGGVORBIS))
            {
                yield return uwr.SendWebRequest();
                if (uwr.result == UnityWebRequest.Result.ConnectionError)
                {
                    Debug.Log("Error");
                }
                else
                {
                    if (GameManager.Instance.MusicSource.clip != null)
                    {
                        GameManager.Instance.MusicSource.Stop();
                        AudioClip currentClip = GameManager.Instance.MusicSource.clip;
                        GameManager.Instance.MusicSource = null;
                        currentClip.UnloadAudioData();
                        
                    }

                    GameManager.Instance.MusicSource.loop = true;
                    GameManager.Instance.MusicSource.volume = .2f;
                    GameManager.Instance.MusicSource.clip = DownloadHandlerAudioClip.GetContent(uwr);
                    GameManager.Instance.MusicSource.Play();
                    yield return null;

                }
            }
        }
        
    }
}