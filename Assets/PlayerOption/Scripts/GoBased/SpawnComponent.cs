using PlayerOption.Scripts.Utils;
using UnityEngine;

namespace PlayerOption.Scripts.GoBased
{
    public class SpawnComponent : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private GameObject prefab;

        [ContextMenu("Spawn")]
        public void Spawn()
        {
            SpawnUtils.Spawn(prefab, target.position);
        }

        public void SetPrefab(GameObject ptefab)
        {
            prefab = ptefab;
        }
    }
}
