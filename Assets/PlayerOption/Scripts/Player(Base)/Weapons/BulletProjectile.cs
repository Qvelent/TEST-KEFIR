using UnityEngine;

namespace PlayerOption.Scripts.Player_Base_.Weapons
{
    public class BulletProjectile : MonoBehaviour
    {
        [SerializeField] private float speedBullet = 8f;
        [SerializeField] private float padding = 0.1f;
        
        private Vector3 _viewportPos;

        private float _top;
        private float _bottom;
        private float _left;
        private float _right;
        
        public virtual void Awake()
        {
            _top = 0.0f - padding;
            _bottom = 1.0f + padding;
            _left = 0.0f - padding;
            _right = 1.0f + padding;
        }
        
        private void Update()
        {
           transform.Translate(0,speedBullet * Time.deltaTime,0);
           
           DestroyBullet();
        }
        
        private void DestroyBullet()
        {
            _viewportPos = Camera.main.WorldToViewportPoint( transform.position );
            
            if( _viewportPos.x < _left ) {
                Destroy(gameObject);
            } else if( _viewportPos.x > _right ) {
                Destroy(gameObject);
            }
            
            if( _viewportPos.y < _top ) {
                Destroy(gameObject);
            } else if( _viewportPos.y > _bottom ) {
                Destroy(gameObject);
            }
        }
    }
}
