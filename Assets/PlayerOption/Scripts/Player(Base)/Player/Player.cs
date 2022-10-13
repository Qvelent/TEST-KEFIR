using System;
using PlayerOption.Scripts.GoBased;
using UnityEngine;

namespace PlayerOption.Scripts.Player_Base_.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private SpawnComponent spawnBullet;
        [SerializeField] private SpawnComponent spawnLaser;
        [SerializeField] private GameObject fireEngine;
        
        
        [SerializeField] private float speed;
        [SerializeField] private float speedRotate = 100f;
        [SerializeField] private float acceleration = 5f;
        
        public float speedFMax = 30f;
        private float _rotate;
        private bool _speeding;

        private void Awake()
        {
            fireEngine.SetActive(false);
        }

        private void FixedUpdate()
        {
            UpdateSpeed();
            MoveRotate();
        }
        private void UpdateSpeed()
        {
            if (_speeding)
            {
                if (speed < speedFMax)
                {
                    fireEngine.SetActive(true);
                    speed += acceleration * Time.deltaTime;
                }
                transform.Translate(0, speed * Time.deltaTime, 0);
            }
            else
            {
                if (speed > 0)
                {
                    fireEngine.SetActive(false);
                    speed -= acceleration * Time.deltaTime;
                }
                transform.Translate(0, speed * Time.deltaTime, 0);
            }
        }
        
        public void ChangeAcceleration(bool accelerationState)
        {
            _speeding = accelerationState;
        }
        
        public void MoveRotate()
        {
            _rotate = Input.GetAxis("Horizontal");
            transform.Rotate(0,0,-_rotate * speedRotate * Time.deltaTime);
        }

        public void FireBullet()
        {
            spawnBullet.Spawn();
        }

        public void FireLaser()
        {
            spawnLaser.SpawnLaser();
        }
    }
}
