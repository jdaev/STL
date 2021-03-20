using System;
using System.IO;
using Base;
using UnityEngine;

namespace Managers
{
    public class LevelManager
    {

        public Level Level{
            get; private set;}
        
        public float PlayerProgress =>
            (GameManager.Instance.PlayerManager.Player.transform.position.z / Level.levelLength) * 100;
        
        

        public void LoadFromJson()
        {
            string json = File.ReadAllText(Application.streamingAssetsPath +"/Maps/map.json");
            Level =  JsonUtility.FromJson<Level>(json);
            
            
        }

    }
}