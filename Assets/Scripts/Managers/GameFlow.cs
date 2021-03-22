using Base;
using UnityEngine;

namespace Managers
{
    public class GameFlow : MonoBehaviour
    {
        [SerializeField] private GameObject rightController;
        [SerializeField] private GameObject leftController;
        [SerializeField] private GameObject headset;
        
        [SerializeField] private Blaster rightBlaster;
        [SerializeField] private Blaster leftBlaster;
        [SerializeField] private Player player;
        
        public void Start()
        {
            GameManager.Instance.Initialize(rightBlaster,leftBlaster,player);
            UIManager.Instance.Initialize();
            ControllerManager.Instance.Initialize(leftController,rightController,headset);
        }

        

        public void Update()
        {
            GameManager.Instance.Refresh();
            UIManager.Instance.Refresh();
        }

        public void FixedUpdate()
        {
        }
    }
}