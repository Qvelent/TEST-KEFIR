using UnityEngine;

namespace PlayerOption.Scripts.SwapScene
{
    public class Swap : SwapScene
    {
        public override void Update()
        {
            base.Update();
            
            if (IsOffscreen)
            {
                transform.position = Camera.main.ViewportToWorldPoint(ViewportPos);
            }
        }
    }
}
