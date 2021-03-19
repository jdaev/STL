using System.IO;
using Base;
using UnityEngine;

namespace Managers
{
    public class LevelManager
    {
        private int levelLength = 385;

        public float PlayerProgress =>
            (GameManager.Instance.PlayerManager.Player.transform.position.z / levelLength) * 100;
        
        

        public void LoadFromJSON()
        {
            string json = File.ReadAllText(Application.streamingAssetsPath +"/Maps/map.json");
            Level level =  JsonUtility.FromJson<Level>(json);
        }

    }
}