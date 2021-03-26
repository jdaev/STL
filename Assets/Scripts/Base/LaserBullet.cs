using Managers;
using UnityEngine;

namespace Base
{
    public class LaserBullet : MonoBehaviour
    {
        [SerializeField] private ParticleSystem flash;
        [SerializeField] private ParticleSystem bullet;
        [SerializeField] private ParticleSystem impact;

        private ParticleSystem _baseParticleSystem;
    
        public void SetColor(STLColor color)
        {
            ParticleSystem.MainModule bulletSettings = bullet.main;
            bulletSettings.startColor = new ParticleSystem.MinMaxGradient( Values.ColorMap[ color] );
        
            ParticleSystem.MainModule flashSettings = flash.main;
            bulletSettings.startColor = new ParticleSystem.MinMaxGradient( Values.ColorMap[ color] );
        
            ParticleSystem.MainModule impactSettings = impact.main;
            bulletSettings.startColor = new ParticleSystem.MinMaxGradient( Values.ColorMap[ color] );
        
        }

        public void Play()
        {
            if (!_baseParticleSystem)
            {
                _baseParticleSystem = GetComponent<ParticleSystem>();
            }
            GameManager.Instance.AudioManager.PlayFireSound();
            _baseParticleSystem.Play();
        }
    }
}
