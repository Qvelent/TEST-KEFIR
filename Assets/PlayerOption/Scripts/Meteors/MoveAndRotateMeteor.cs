using UnityEngine;

namespace PlayerOption.Scripts.Meteors
{
    public class MoveAndRotateMeteor : MonoBehaviour
    {
        [SerializeField] private float speed = 1.0f;

        private void Start()
        {
            float posRotateZ = Random.Range(-360, 360);
            transform.Rotate(0,0,posRotateZ);
        }

        private void Update() {
            transform.Translate( transform.up * (speed * Time.deltaTime), Space.World );
        }
    }
}
