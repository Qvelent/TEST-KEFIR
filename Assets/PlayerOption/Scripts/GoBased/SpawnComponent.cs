
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

        public IEnumerator SpawnLaserCoroutine()
        {
            GameObject go = SpawnUtils.Spawn(prefab, target.position, Quaternion.identity);
            //go.transform.SetParent(target.transform);
            go.transform.SetPositionAndRotation(target.transform.position, gameObject.transform.rotation);
            yield return new WaitForSeconds(3f);
            Destroy(go);
        }
        
        public void SetPrefab(GameObject ptefab)
        {
            prefab = ptefab;
        }
    }
}
