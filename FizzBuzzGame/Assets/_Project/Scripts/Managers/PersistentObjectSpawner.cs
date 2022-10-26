using System.Collections.Generic;
using UnityEngine;

namespace AlphDevCode.Managers
{
    public class PersistentObjectSpawner : MonoBehaviour
    {
        [Tooltip("These prefabs will only be spawned once and be persisted between scenes")]
        [ SerializeField] 
        private List <PersistentObject> persistentObjectPrefabs;

        private bool _hasSpawned;
        private void Awake()
        {
            if (_hasSpawned) return;
            SpawnPersistentObjects();
            _hasSpawned = true;
        }

        private void SpawnPersistentObjects()
        {
            foreach (var persistentObjectPrefab in persistentObjectPrefabs)
            {
                GameObject persistentObject = Instantiate(persistentObjectPrefab.prefab);
                persistentObject.name = persistentObjectPrefab.nameOfObject ?? persistentObjectPrefab.prefab.name;
                DontDestroyOnLoad(persistentObject);
            }
        }
    }
}