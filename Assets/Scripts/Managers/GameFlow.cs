using UnityEngine;

namespace Managers
{
    public class GameFlow : MonoBehaviour
    {
        [SerializeField] private GameObject rightController;
        [SerializeField] private GameObject leftController;
        [SerializeField] private GameObject headset;
        
        [SerializeField] private Blaster blaster;
        
        
        public void Awake()
        {
            GameManager.Instance.Initialize(blaster);
            UIManager.Instance.Initialize();
            InputManager.Instance.Initialize(leftController,rightController,headset);
        }

        public void Start()
        {
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