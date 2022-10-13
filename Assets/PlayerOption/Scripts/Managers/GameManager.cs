using UnityEngine;

namespace PlayerOption.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;

        public static GameManager Instance
        {
            get { return _instance; }
        }

        [SerializeField] private LevelManager levelManager;

        [SerializeField] private GameObject gameHolder;

        [SerializeField] private int startingLives = 3;

        public int Lives { get; private set; }

        public int Points { get; private set; }

        public int Level
        {
            get { return levelManager.Level; }
        }

        void Awake()
        {
            DontDestroyOnLoad(gameObject);
            
            gameHolder.SetActive(false);

            levelManager.EventPoints += OnLevelPoints;
            levelManager.EventPlayerDied += OnLevelLives;
        }

        public void StartGame()
        {
            gameHolder.SetActive(true);

            ResetGame();
            levelManager.StartLevel();
        }

        public void ResetGame()
        {
            Points = 0;
            Lives = startingLives;
            levelManager.Reset();

        }

        private void OnLevelPoints(int points)
        {
            Points += points;
        }

        private void OnLevelLives()
        {
            Lives -= 1;
            if (Lives >= 0)
            {
                Debug.Log($"Player lives: {Lives}");
            }

        }

    }
}
