using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerOption.Scripts.Player_Base_.Player
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private Player player;
        
        public void OnMovementForwardInput(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                player.ChangeAcceleration(true);
            }

            if (context.canceled)
            {
                player.ChangeAcceleration(false);
            }
        }

        public void OnRotateLeftAndRightInput(InputAction.CallbackContext context)
        {
            player.MoveRotate();
        }
        
        public void OnFireBullet(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                player.FireBullet();
            }
        }
        
        public void OnFireLaser(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                player.FireLaser();
            }
        }
    }
}
