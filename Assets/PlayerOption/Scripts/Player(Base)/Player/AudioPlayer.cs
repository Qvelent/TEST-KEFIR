using UnityEngine;

namespace PlayerOption.Scripts.Player_Base_.Player
{
    public class AudioPlayer : MonoBehaviour
    {
        public static AudioPlayer Instance;
        
        [Header("Shooting")]
        [SerializeField] AudioClip shootingClip;
        [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;

        [Header("Hit")]
        [SerializeField] private AudioClip damageClip;
        [SerializeField] [Range(0f, 1f)] private float damageVolume = 1f;
        
        [Header("Explosion")]
        [SerializeField] private AudioClip explosionClip;
        [SerializeField] [Range(0f, 1f)] private float explosionVolume = 1f;

        private void Awake()
        {
            Instance = this;
        }

        public void PlayShootingClip()
        {
            PlayClip(shootingClip, shootingVolume);
        }

        public void PlayDamageClip()
        {
            PlayClip(damageClip, damageVolume);
        }

        public void PlayExplosionClip()
        {
            PlayClip(explosionClip, explosionVolume);
        }

        static void PlayClip(AudioClip clip, float volume)
        {
            if (clip == null) return;
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
}
