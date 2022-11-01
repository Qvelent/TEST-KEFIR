using UnityEngine;
using UnityEngine.SceneManagement;

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
        
        public int Points { get; private set; }
        
        void Awake()
        {
            DontDestroyOnLoad(gameObject);

            gameHolder.SetActive(false);

            levelManager.EventPoints += OnLevelPoints;
        }

        public void StartGame()
        {
            gameHolder.SetActive(true);

            ResetGame();
            levelManager.StartLevel();
        }

        public void ResetGame()
        {
            //SceneManager.LoadScene(0);
        }

        private void OnLevelPoints(int points)
        {
            Points += points;
        }
    }
}
