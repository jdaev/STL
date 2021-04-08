using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace Managers
{
    public class AudioManager
    {
        private AudioSource _audioSource;

        private AudioClip _fireClip;
        private AudioClip _enemyKillClip;

        private AudioClip _musicClip;
        private string _musicFile;


        private GameFlow _gameFlow;


        public void Initialize()
        {
            _audioSource = (AudioSource) GameManager.Instance.GameAudioSource;
            _enemyKillClip = Resources.Load<AudioClip>("Sounds/BassDrop");
            _fireClip = Resources.Load<AudioClip>("Sounds/ShotAlt");

            _gameFlow = GameObject.Find("MainScripts").GetComponent<GameFlow>();
        }

        public void Refresh()
        {
        }

        public void PlaySoundtrack()
        {
            _musicFile = GameManager.Instance.Level.soundtrack.ToLower().Replace(" ", string.Empty) + ".ogg";
            _gameFlow.StartCoroutine(MusicPlayer());
        }

        public void PlayFireSound()
        {
            _audioSource.PlayOneShot(_fireClip, 10);
        }

        public void PlayEnemyDeathSound()
        {
            _audioSource.PlayOneShot(_enemyKillClip, 10);
        }


        IEnumerator MusicPlayer()
        {
            Debug.Log(GetFileLocation(_musicFile));
            using UnityWebRequest uwr =
                UnityWebRequestMultimedia.GetAudioClip(GetFileLocation(_musicFile), AudioType.OGGVORBIS);
            yield return uwr.SendWebRequest();
            if (uwr.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("Error");
            }
            else
            {
                if (_audioSource.clip != null)
                {
                    _audioSource.Stop();
                    AudioClip currentClip = _audioSource.clip;
                    _audioSource = null;
                    currentClip.UnloadAudioData();
                }

                _audioSource.loop = true;
                _audioSource.volume = .2f;
                _audioSource.clip = DownloadHandlerAudioClip.GetContent(uwr);
                _audioSource.Play();
                yield return null;
            }
        }

        private static string GetFileLocation(string relativePath)
        {
            string url;
            #if UNITY_EDITOR || !UNITY_ANDROID
                url = "file://" + Path.Combine(Path.Combine(Application.streamingAssetsPath, "Music"), relativePath);
            #else
                url = "jar:file://" + Application.dataPath + "!/assets/" + Path.Combine("Music", relativePath);
            #endif
            
            return url;
        }
    }
}