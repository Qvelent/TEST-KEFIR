using System;
using UnityEngine;
using UnityEngine.Events;

namespace PlayerOption.Scripts.Health
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int maxHealth;
        [SerializeField] private UnityEvent onDamage;
        [SerializeField] public UnityEvent onDie;

        public int Health => maxHealth;
        

        public void ModifyHealth(int hpDelta)
        {
            if (maxHealth <= 0) return;
            
            maxHealth += hpDelta;

            if (hpDelta < 0)
            {
                onDamage?.Invoke();
                Debug.Log("Оставшееся хп: " + maxHealth);
            }
            
            if (maxHealth <= 0)
            {
                onDie?.Invoke();
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
