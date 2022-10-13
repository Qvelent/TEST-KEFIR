
using System.Collections;
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
            SpawnUtils.Spawn(prefab, target.position, target.rotation);
        }

        public void SpawnLaser()
        {
            StartCoroutine(SpawnLaserCoroutine());
        }

        private IEnumerator SpawnLaserCoroutine()
        {
            GameObject go = SpawnUtils.Spawn(prefab, target.position, target.rotation);
            go.transform.SetParent(target.transform);
            yield return new WaitForSeconds(3f);
            Destroy(go);
        }
        
        public void SetPrefab(GameObject ptefab)
        {
            prefab = ptefab;
        }
    }
}
