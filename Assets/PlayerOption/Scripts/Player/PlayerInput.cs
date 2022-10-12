using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerOption.Scripts.Player
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
    }
}
