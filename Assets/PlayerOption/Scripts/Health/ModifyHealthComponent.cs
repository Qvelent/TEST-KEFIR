using UnityEngine;

namespace PlayerOption.Scripts.Health
{
    public class ModifyHealthComponent : MonoBehaviour
    {
        [SerializeField] private int hpDelta;

        public void ApplyHealthDelta(GameObject target)
        {
            var healthComponent = target.GetComponent<HealthComponent>();
            if (healthComponent != null)
            {
                healthComponent.ModifyHealth(hpDelta);
            }
        }
    }
}
