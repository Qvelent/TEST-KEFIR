using UnityEngine;

namespace PlayerOption.Scripts.SwapScene
{
    public class SwapScene : MonoBehaviour
    {
        [SerializeField] private float padding = 0.1f;

        protected bool IsOffscreen;
        protected Vector3 ViewportPos;

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

        public virtual void Update()
        {
            Spaw();
        }

        private void Spaw()
        {
            ViewportPos = Camera.main.WorldToViewportPoint( transform.position );
            IsOffscreen = false;
            
            if( ViewportPos.x < _left ) {
                ViewportPos.x = _right;
                IsOffscreen = true;
            } else if( ViewportPos.x > _right ) {
                ViewportPos.x = _left;
                IsOffscreen = true;
            }
            
            if( ViewportPos.y < _top ) {
                ViewportPos.y = _bottom;
                IsOffscreen = true;
            } else if( ViewportPos.y > _bottom ) {
                ViewportPos.y = _top;
                IsOffscreen = true;
            }
        }
    }
}
