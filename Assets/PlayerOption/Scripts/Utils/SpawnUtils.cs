using UnityEngine;

namespace PlayerOption.Scripts.Utils
{
    public class SpawnUtils
    {
        private const string ContainerName = "-----SPAWNED-----";

        public static GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotate)
        {
            var container = GameObject.Find(ContainerName);
            if (container == null)
                container = new GameObject(ContainerName);
            
            return Object.Instantiate(prefab, position, rotate, container.transform);
           // return Object.Instantiate(prefab, position, Quaternion.identity, container.transform);
        }
    }
}
