using System;
using PlayerOption.Scripts.Player_Base_.Player;
using UnityEngine;
using UnityEngine.Events;

namespace PlayerOption.Scripts.Health
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int maxHealth;
        [SerializeField] private UnityEvent onDamage;
        [SerializeField] public UnityEvent onDie;
        [SerializeField] private ParticleSystem _explosion;

        public int Health => maxHealth;
        
        public void ModifyHealth(int hpDelta)
        {
            if (maxHealth <= 0) return;
            
            maxHealth += hpDelta;

            if (hpDelta < 0)
            {
                onDamage?.Invoke();
                AudioPlayer.Instance.PlayDamageClip();
                PlayHitEffect();
            }
            
            if (maxHealth <= 0)
            {
                AudioPlayer.Instance.PlayExplosionClip();
                onDie?.Invoke();
            }
        }
        
        void PlayHitEffect()
        {
            if(_explosion != null)
            {
                ParticleSystem istance = Instantiate(_explosion, transform.position , Quaternion.identity);
                Destroy(istance.gameObject, istance.main.duration + istance.main.startLifetime.constantMax);
            }
        }

        public void SetHealth(int health)
        {
            maxHealth = health;
        }

        private void OnDestroy()
        {
            onDie.RemoveAllListeners();
        }

        [Serializable]
        public class HealthChangeEvent : UnityEvent<int>
        {
        }
    }
}
