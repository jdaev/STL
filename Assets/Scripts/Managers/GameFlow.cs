using UnityEngine;

namespace Managers
{
    public class GameFlow : MonoBehaviour
    {
        [SerializeField] private GameObject rightController;
        [SerializeField] private GameObject leftController;
        [SerializeField] private GameObject headset;
        
        [SerializeField] private Blaster blaster;
        [SerializeField] private Player player;
        
        public void Awake()
        {
            GameManager.Instance.Initialize(blaster,player);
            UIManager.Instance.Initialize();
            ControllerManager.Instance.Initialize(leftController,rightController,headset);
            BulletFactory.Instance.Initialize();
            BulletManager.Instance.Initialize();
        }

        public void Start()
        {
        }

        public void Update()
        {
            GameManager.Instance.Refresh();
            UIManager.Instance.Refresh();
            BulletManager.Instance.Refresh();
        }

        public void FixedUpdate()
        {
        }
    }
}