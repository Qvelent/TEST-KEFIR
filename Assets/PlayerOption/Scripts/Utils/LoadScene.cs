using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlayerOption.Scripts.Utils
{
    public class LoadScene : MonoBehaviour
    {
        void Start()
        {
            Load();
        }
        
        public void Load()
        {
            SceneManager.LoadScene(1);
        }
    }
}
