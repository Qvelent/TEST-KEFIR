using System;
using PlayerOption.Scripts.Meteors;
using PlayerOption.Scripts.Player_Base_.Player;
using UnityEngine;

namespace PlayerOption.Scripts.Managers
{
    public class LevelManager : MonoBehaviour
    {
        public event Action<int> EventPoints;
        public event Action EventPlayerDied;

        [SerializeField] private int level;

        public int Level
        {
            get { return level; }
            private set { level = value; }
        }

        [SerializeField] private SpawnMeteors meteorsSpawner;

        [SerializeField] private Player player;

        [SerializeField] private float startLevelDelay = 3.0f;
        

        public void Reset()
        {
            level = 1;
        }

        public void StartLevel()
        {
            meteorsSpawner.Spawn(level);
            //EventStarted?.Invoke();
        }
        

        private void OnAsteroidDestroyed(int points)
        {
            EventPoints?.Invoke(points);
            
            level += 1;
            Invoke("StartLevel", startLevelDelay);
        }

        private void OnPlayerDied()
        {
            EventPlayerDied?.Invoke();
        }
    }
}

