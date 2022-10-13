using UnityEngine;

namespace PlayerOption.Scripts.GoBased
{
    public class DestroyObjectComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _gameObject;
        
        public void DestroyObject()
        {
            Destroy(_gameObject);
        }
    }
}
