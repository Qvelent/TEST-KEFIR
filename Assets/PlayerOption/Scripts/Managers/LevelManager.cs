using System;
using PlayerOption.Scripts.Meteors;
using PlayerOption.Scripts.Player_Base_.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlayerOption.Scripts.Managers
{
    public class LevelManager : MonoBehaviour
    {
        public event Action<int> EventPoints;
        public event Action EventPlayerDied;

        

        [SerializeField] private SpawnMeteors meteorsSpawner;

        [SerializeField] private Player player;
        private bool _isAlive;
        

        public void Reset()
        {
            //SceneManager.LoadScene(0);
        }

        public void StartLevel()
        {
            meteorsSpawner.Spawn();
        }
        

        private void OnAsteroidDestroyed(int points)
        {
            EventPoints?.Invoke(points);
            
            
            Invoke("StartLevel", 3f);
        }

        private void OnPlayerDied()
        {
            EventPlayerDied?.Invoke();
        }
    }
}

