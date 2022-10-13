using System;
using UnityEngine;

namespace PlayerOption.Scripts.Player_Base_.Player
{
    public class AudioPlayer : MonoBehaviour
    {
        public static AudioPlayer instance;
        
        [Header("Shooting")]
        [SerializeField] AudioClip shootingClip;
        [SerializeField] [Range(0f, 1f)] float ShootingValume = 1f;

        [Header("Hit")]
        [SerializeField] AudioClip damageClip;
        [SerializeField] [Range(0f, 1f)] float damageValume = 1f;
        
        [Header("Explosion")]
        [SerializeField] AudioClip explosionClip;
        [SerializeField] [Range(0f, 1f)] float explosionValume = 1f;

        private void Awake()
        {
            instance = this;
        }

        public void PlayShootingClip()
        {
            PlayClip(shootingClip, ShootingValume);
        }

        public void PlayDamageClip()
        {
            PlayClip(damageClip, damageValume);
        }

        public void PlayExplosionClip()
        {
            PlayClip(explosionClip, explosionValume);
        }

        void PlayClip(AudioClip clip, float valume)
        {
            if(clip != null)
            {
                Vector3 cameraPos = Camera.main.transform.position;
                AudioSource.PlayClipAtPoint(clip, cameraPos, valume);
            }
        }
    }
}
